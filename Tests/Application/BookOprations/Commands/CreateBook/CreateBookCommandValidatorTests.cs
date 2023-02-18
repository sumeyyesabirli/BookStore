using FluentAssertions;
using System;
using Tests.TestSetup;
using WebApi.BookOperations.CreateBook;
using Xunit;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;

namespace Tests.Application.BookOprations.Commands.CreateBook
{
    public class CreateBookCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory] // Theory :birdan fazla calıstırmak için.
        [InlineData("Dijital Kale", 0, 0)]
        [InlineData("Dijital Kale", 0, 1)]
        [InlineData("Dijital Kale", 100, 0)]
        [InlineData(" ", 100, 0)]
        [InlineData("", 100, 0)]
        [InlineData("", 100, 1)]
        [InlineData("", 0, 0)]
        [InlineData("Diji", 100, 0)]
        [InlineData("Diji", 0, 1)]
        public void WhenInvalidInputsAreGiven_Validator_ShoulBeReturnErrors(string title, int pageCount, int genreId)
        {
            //Arrange
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel()
            {
                Title = title,
                PageCount = pageCount,
                GenreId = genreId,
                PublishDate = DateTime.Now.Date.AddYears(-1)
            };
            //Arc
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);

            //Assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
