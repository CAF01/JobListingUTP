using FluentValidation;
using JobList.Entities.Helpers;
using JobList.Entities.Requests;

namespace JobList.Framework.Validations.Administrador
{
    public class ReadDetallesEmpresaValidator : AbstractValidator<ReadDetallesEmpresaRequest>
    {
        public ReadDetallesEmpresaValidator()
        {
            RuleFor(data => data.idUsuarioEmpresa).NotNull().NotEmpty().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
