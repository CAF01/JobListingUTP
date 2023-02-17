namespace JobList.Framework.Validations.Egresados
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;

    public class GetEgresadoHabilidadesValidation : AbstractValidator<GetEgresadoHabilidadesRequest>
    {
        public GetEgresadoHabilidadesValidation()
        {
            RuleFor(data => data.idUsuario).NotNull().NotEmpty().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
