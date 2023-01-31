namespace JobList.Framework.Validations.Egresados
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;
    public class insertConocimientoEgresadoValidation : AbstractValidator<insertConocimientoEgresadoRequest>
    {
        public insertConocimientoEgresadoValidation()
        {
            RuleFor(data => data.idUsuarioEgresado).NotEmpty().NotNull().GreaterThan(ValidatorHelper.ZERO);
            RuleFor(data => data.idConocimiento).NotEmpty().NotNull().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
