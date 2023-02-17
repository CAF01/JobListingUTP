namespace JobList.Framework.Validations.Empresas
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;

    public class GetEmpresaListaOfertasActivasValidation : AbstractValidator<GetEmpresaListaOfertasActivasRequest>
    {
        public GetEmpresaListaOfertasActivasValidation()
        {
            RuleFor(data => data.idUsuario).NotNull().NotEmpty().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
