using FluentValidation;
using RoadmApp.Domain.Models;

namespace RoadmApp.Domain.Validations
{
    public class ContactValidation : AbstractValidator<ContactModel>
    {
        public ContactValidation()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email é obrigatório.")
                .EmailAddress().WithMessage("Email inválido.");

            /*RuleFor(x => x.Cellphone)
                .NotEmpty().WithMessage("Celular é obrigatório.")
                .Matches(@"^\d+$")
                .WithMessage("Celular deve conter apenas números.")
                .MinimumLength(9)
                .WithMessage("Celular inválido.");*/
        }
    }
}