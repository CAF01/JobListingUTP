namespace JobList.Framework.Validations.Egresados
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;

    public class GetEgresadoListaOfertasActivasValidation : AbstractValidator<GetEgresadoListaOfertasActivasRequest>
    {
        public GetEgresadoListaOfertasActivasValidation()
        {
            RuleFor(data => data.idUsuario).NotNull().NotEmpty().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
