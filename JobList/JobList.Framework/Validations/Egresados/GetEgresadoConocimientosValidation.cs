namespace JobList.Framework.Validations.Egresados
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;

    public class GetEgresadoConocimientosValidation : AbstractValidator<GetEgresadoConocimientosRequest>
    {
        public GetEgresadoConocimientosValidation()
        {
            RuleFor(data => data.idUsuario).NotNull().NotEmpty().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
