namespace JobList.Framework.Validations.Empresas
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;

    public class ReadOfertasPublicadasEmpresaValidation : AbstractValidator<ReadOfertasPublicadasEmpresaRequest>
    {
        public ReadOfertasPublicadasEmpresaValidation()
        {
            RuleFor(data => data.idUsuarioEmpresa).NotNull().NotEmpty().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
