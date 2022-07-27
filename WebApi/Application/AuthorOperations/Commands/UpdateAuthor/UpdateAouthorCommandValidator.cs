using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAouthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAouthorCommandValidator()
        {
            RuleFor(x => x.Model.Name).MinimumLength(2).When(x => x.Model.Name != string.Empty);

            RuleFor(x => x.Model.lastName).MinimumLength(2).When(x => x.Model.lastName != string.Empty);

            RuleFor(x => x.Model.BookId).NotEmpty().GreaterThan(0);

         
        }
    }
}
