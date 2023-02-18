using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.TestSetup;
using WebApi.BookOperations.UpdateBook;
using WebApi.EfDbContext;
using WebApi.Entities;
using Xunit;

namespace Tests.Application.BookOprations.Commands.UpdateBook
{
    public class UpdateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly DbContextBooksStore context;
        private readonly IMapper mapper;

        public UpdateBookCommandTests(CommonTestFixture testFixture)
        {
            this.context = testFixture.Context;
            this.mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGivenBookIsNotFound_InvalidOperationException_ShouldBeReturn()
        {
            // arrange (Hazırlık)

            UpdateBookCommand command = new(context);
            command.BookId = 999;

            // act & assert (Çalıştırma - Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Güncellenecek Kitap Bulunamadı");

            // act (Çalıştırma)

            // assert (Doğrulama)
        }

        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeUpdated()
        {
            // arrange
            UpdateBookCommand command = new(context);
            var book = new Book { Title = "Test Book", GenreId = 1, AuthorId = 1, PageCount = 100, PublisDate = new DateTime(2022, 1, 1) };

            context.Books.Add(book);
            context.SaveChanges();

            command.BookId = book.Id;
            UpdateBookCommand.UpdateBookModel model = new UpdateBookCommand.UpdateBookModel { Title = "Updated Title", GenreId = 2, };
            command.Model = model;

            // act
            FluentActions.Invoking(() => command.Handle()).Invoke();
            // assert
            var updatedBook = context.Books.SingleOrDefault(b => b.Id == book.Id);
            updatedBook.Should().NotBeNull();
            updatedBook.PageCount.Should().Be(book.PageCount);
            updatedBook.PublisDate.Should().Be(book.PublisDate);
            updatedBook.Title.Should().Be(model.Title);
            updatedBook.GenreId.Should().Be(model.GenreId);

        }
    }
}
