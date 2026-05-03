using FluentValidation;
using RoadmApp.Domain.BusinessModel;

namespace RoadmApp.Domain.Validations
{
    public class FirstAccessValidation : AbstractValidator<FirstAccessLogin>
    {
        public FirstAccessValidation()
        {
            RuleFor(x => x.Nickname)
                .NotEmpty().WithMessage("Nickname é obrigatório.")
                .MinimumLength(4).WithMessage("Nickname deve ter no mínimo 4 caracteres.");

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("Senha é obrigatória.")
                .MinimumLength(6).WithMessage("Senha deve ter no mínimo 6 caracteres.");

            RuleFor(x => x.ConfirmNewPassword)
                .NotEmpty().WithMessage("Confirmação de senha é obrigatória.")
                .Equal(x => x.NewPassword).WithMessage("As senhas não coincidem.");
        }
    }
}