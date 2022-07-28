using FluentValidation;
using System;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator:AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(command => command.Model.Name).MinimumLength(2).NotEmpty();
            RuleFor(command => command.Model.BirthDay).NotEmpty().LessThan(DateTime.Now.Date);

        }
    }
    
}
