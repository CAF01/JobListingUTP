namespace JobList.Framework.Validations.Empresas
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;

    public class GetEmpresaOfertasHistorialValidation : AbstractValidator<GetEmpresaOfertasHistorialRequest>
    {
        public GetEmpresaOfertasHistorialValidation()
        {
            RuleFor(data => data.idUsuario).NotNull().NotEmpty().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
