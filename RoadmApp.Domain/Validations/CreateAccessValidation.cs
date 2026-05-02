using FluentValidation;
using RoadmApp.Domain.BusinessModel;

namespace RoadmApp.Domain.Validations
{
    public class CreateAccessValidation : AbstractValidator<Register>
    {
        public CreateAccessValidation()
        {
            RuleFor(x => x.Access)
                .NotNull().WithMessage("Access é obrigatório.")
                .SetValidator(new AccessValidation());

            RuleFor(x => x.User)
                .NotNull().WithMessage("User é obrigatório.")
                .SetValidator(new UserValidation());
             
            RuleFor(x => x.Contacts)
                .NotNull().WithMessage("Lista de contatos é obrigatória.") 
                .WithMessage("Deve haver ao menos um contato.")
                .SetValidator(new ContactValidation());
        }
    }
}