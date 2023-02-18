using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.TestSetup;
using WebApi.BookOperations.CreateBook;
using WebApi.EfDbContext;
using WebApi.Entities;
using Xunit;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;

namespace Tests.Application.BookOprations.Commands.CreateBook
{
    public class CreateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly DbContextBooksStore _context;
        private readonly IMapper _mapper;

        public CreateBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShoulBeReturn()
        {
            //Arrange (Hazırlık)
            var book = new Book() { Title = "Test_WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShoulBeReturn", GenreId = 1, PageCount = 100, PublisDate = new DateTime(1999, 06, 07) };
            _context.Add(book);
            _context.SaveChanges();

            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            command.Model = new CreateBookModel() { Title = book.Title };

            //Act & Assert (Calıstır & Doğrulama)
            FluentActions
            .Invoking(() => command.Handle())
            .Should().Throw<InvalidOperationException>().And.Message.Should()
            .Be("Bu Kitap Ekli");

        }

        [Fact]
        public void WhenValidInputTitleGiven_Book_Created()
        {
            // Arrenge
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            CreateBookModel model = new CreateBookModel() { Title = "SMTcoder2", PageCount = 1000, PublishDate = DateTime.Now.Date.AddYears(-10), GenreId = 1 };
            command.Model = model;

            // Arc
            FluentActions.Invoking(() => command.Handle()).Invoke();

            // Assert
            var book = _context.Books.SingleOrDefault(book => book.Title == model.Title);
            book.Should().NotBeNull();
            book.PageCount.Should().Be(model.PageCount);
            book.GenreId.Should().Be(model.GenreId);
            //book.PublishDate.Should().Be(model.PublisDate);


        }
    }
}
