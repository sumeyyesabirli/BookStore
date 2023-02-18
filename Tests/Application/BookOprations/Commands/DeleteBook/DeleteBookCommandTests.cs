using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.TestSetup;
using WebApi.BookOperations.DeleteBook;
using WebApi.EfDbContext;
using Xunit;

namespace Tests.Application.BookOprations.Commands.DeleteBook
{
    public class DeleteBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly DbContextBooksStore context;

        public DeleteBookCommandTests(CommonTestFixture testFixture)
        {
            this.context = testFixture.Context;
        }

        [Fact]
        public void WhenGivenBookIsNotFound_InvalidOperationException_ShouldBeReturn()
        {
            // arrange (Hazırlık)

            DeleteBookCommand command = new(context);
            command.BookId = 12;

            // act & assert (Çalıştırma - Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Silinecek Kitap Bulunamadı");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Book_ShouldBeDeleted()
        {
            // arrange
            DeleteBookCommand command = new(context);
            command.BookId = 1;

            // act
            FluentActions.Invoking(() => command.Handle()).Invoke();
            // assert
            var book = context.Books.SingleOrDefault(b => b.Id == command.BookId);
            book.Should().BeNull();
        }
    }
}
