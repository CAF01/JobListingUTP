namespace JobList.Framework.Validations.Egresados
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;

    public class GetEgresadoExpLaboralValidation : AbstractValidator<GetEgresadoExpLaboralRequest>
    {
        public GetEgresadoExpLaboralValidation()
        {
            RuleFor(data => data.idUsuario).NotNull().NotEmpty().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
