using FluentValidation;
using Modulos.IO.Domain.Clientes.Commands;

namespace Modulos.IO.Domain.Validations.Clientes
{
    public abstract class ClienteValidation<T> : AbstractValidator<T> where T : BaseClienteCommand
    {

        protected void ValidarRazaoSocial()
        {
            RuleFor(c => c.RazaoSocial)
                .NotEmpty().WithMessage("O campo Razão Social é obrigatório")
                .Length(2, 200).WithMessage("O campo Razão Social deve possuir entre 2 e 200 caracteres!");
        }

        protected void ValidarCnpj()
        {
            RuleFor(c => c.Cnpj)
               .Length(18).WithMessage("O campo Cnpj deve possuir 18 caracteres!");
        }
    }
}
