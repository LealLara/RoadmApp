using FluentValidation;
using RoadmApp.Domain.Entities;
using RoadmApp.Domain.Models;

namespace RoadmApp.Domain.Validations
{
    public class AccessValidation : AbstractValidator<AccessModel>
    {
        public AccessValidation()
        {
            RuleFor(x => x.Nickname)
                .NotEmpty().WithMessage("Nickname é obrigatório.")
                .MinimumLength(4).WithMessage("Nickname deve ter no mínimo 4 caracteres.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Senha é obrigatória.")
                .MinimumLength(6).WithMessage("Senha deve ter no mínimo 6 caracteres.");
        }
    }
}
