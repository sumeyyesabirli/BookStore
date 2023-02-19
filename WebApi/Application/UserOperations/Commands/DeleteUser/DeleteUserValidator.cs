using FluentValidation;

namespace WebApi.Application.UserOperations.Commands.DeleteUser
{
    public class DeleteUserValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserValidator()
        {
            RuleFor(x => x.UserID).NotEmpty().GreaterThan(0);
        }
    }
}
