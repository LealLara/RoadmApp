using FluentValidation;
using RoadmApp.Domain.BusinessModel;

namespace RoadmApp.Domain.Validations
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MinimumLength(3);

            RuleFor(x => x.Birthday)
                .NotEmpty().WithMessage("Data de nascimento é obrigatória.")
                .LessThan(DateTime.Now)
                .WithMessage("Data de nascimento deve ser no passado.");
        }
    }
}