﻿using FluentValidation;
using System;

namespace WebApi.BookOperations.CreateBook
{
    public class CreateBookCommandValidator: AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(command=> command.Model.GenreId).GreaterThan(0);
            RuleFor(command=> command.Model.PageCount).GreaterThan(0);
            RuleFor(command => command.Model.PublisDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);
        }
    }
}
