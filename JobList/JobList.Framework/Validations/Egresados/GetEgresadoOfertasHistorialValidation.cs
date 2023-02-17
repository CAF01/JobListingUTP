namespace JobList.Framework.Validations.Egresados
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;

    public class GetEgresadoOfertasHistorialValidation : AbstractValidator<GetEgresadoOfertasHistorialRequest>
    {
        public GetEgresadoOfertasHistorialValidation()
        {
            RuleFor(data => data.idUsuario).NotNull().NotEmpty().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
