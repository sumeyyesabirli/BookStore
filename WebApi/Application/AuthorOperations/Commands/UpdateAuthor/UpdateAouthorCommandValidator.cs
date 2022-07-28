using FluentValidation;
using System;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAouthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAouthorCommandValidator()
        {
            RuleFor(command => command.AuthorId).GreaterThan(0);
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.Birthday).NotEmpty().LessThan(DateTime.Now);


        }
    }
}
