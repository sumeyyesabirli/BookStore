using FluentValidation;

namespace WebApi.Application.UserOperations.Queries.GetDetailUser
{
    public class GetDetailUserValidator : AbstractValidator<GetDetailUserQuery>
    {
        public GetDetailUserValidator()
        {

            RuleFor(x => x.UserID).NotEmpty().WithMessage("Id boş olamaz ! ");

        }
    }
}
