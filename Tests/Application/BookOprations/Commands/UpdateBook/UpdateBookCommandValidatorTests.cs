using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.TestSetup;
using WebApi.BookOperations.UpdateBook;
using Xunit;

namespace Tests.Application.BookOprations.Commands.UpdateBook
{
    public class UpdateBookCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        private UpdateBookCommandValidator _validator;

        public UpdateBookCommandValidatorTests()
        {
            _validator = new();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void WhenBookIdIsInvalid_Validator_ShouldHaveError(int bookId)
        {
            // arrange
            var model = new UpdateBookCommand.UpdateBookModel { Title = "Right Title", GenreId = 3, };
            UpdateBookCommand command = new(null);
            command.Model = model;
            command.BookId = bookId;

            // act
            var result = _validator.Validate(command);

            // assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData(null, 0)]
        [InlineData("x", 1)]
        [InlineData("123", 2)]
        public void WhenModelIsInvalid_Validator_ShouldHaveError(string title, int genreId)
        {
            // arrange
            var model = new UpdateBookCommand.UpdateBookModel { Title = title, GenreId = genreId};
            UpdateBookCommand updateCommand = new(null);
            updateCommand.BookId = 1;
            updateCommand.Model = model;

            // act
            var result = _validator.Validate(updateCommand);

            // assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData("Title", 1)]
        [InlineData("Long Title", 2)]
        public void WhenInputsAreValid_Validator_ShouldNotHaveError(string title, int genreId)
        {
            // arrange
            var model = new UpdateBookCommand.UpdateBookModel { Title = title, GenreId = genreId };
            UpdateBookCommand updateCommand = new(null);
            updateCommand.BookId = 2;
            updateCommand.Model = model;

            // act
            var result = _validator.Validate(updateCommand);

            // assert
            result.Errors.Count.Should().Be(0);
        }
    }
}
