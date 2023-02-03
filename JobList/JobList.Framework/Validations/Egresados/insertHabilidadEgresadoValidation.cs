namespace JobList.Framework.Validations.Egresados
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;
    public class InsertHabilidadEgresadoValidation : AbstractValidator<InsertHabilidadEgresadoRequest>
    {
        public InsertHabilidadEgresadoValidation()
        {
            RuleFor(data => data.idUsuarioEgresado).NotEmpty().NotNull().GreaterThan(ValidatorHelper.ZERO);
            RuleFor(data => data.idHabilidad).NotEmpty().NotNull().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
