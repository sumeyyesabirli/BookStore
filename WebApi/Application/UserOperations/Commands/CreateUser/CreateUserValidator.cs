using FluentValidation;

namespace WebApi.Application.UserOperations.Commands.CreateUser
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {

            RuleFor(x => x.Model.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Model.Name).NotEmpty();
            RuleFor(x => x.Model.LastName).NotEmpty();
            RuleFor(x => x.Model.Password).NotEmpty().MinimumLength(6);
        }
    }
}
