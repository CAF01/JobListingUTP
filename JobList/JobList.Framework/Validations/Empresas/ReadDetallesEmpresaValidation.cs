namespace JobList.Framework.Validations.Empresas
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;

    public class ReadDetallesEmpresaValidation : AbstractValidator<ReadDetallesEmpresaRequest>
    {
        public ReadDetallesEmpresaValidation()
        {
            RuleFor(data => data.idUsuarioEmpresa).NotNull().NotEmpty().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
