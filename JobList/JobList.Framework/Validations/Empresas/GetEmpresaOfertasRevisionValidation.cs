namespace JobList.Framework.Validations.Empresas
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;

    internal class GetEmpresaOfertasRevisionValidation : AbstractValidator<GetEmpresaOfertasRevisionRequest>
    {
        public GetEmpresaOfertasRevisionValidation() 
        {
            RuleFor(data => data.idUsuario).NotNull().NotEmpty().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
