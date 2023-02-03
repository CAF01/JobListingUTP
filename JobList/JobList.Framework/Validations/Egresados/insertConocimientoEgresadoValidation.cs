namespace JobList.Framework.Validations.Egresados
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;
    public class InsertConocimientoEgresadoValidation : AbstractValidator<InsertConocimientoEgresadoRequest>
    {
        public InsertConocimientoEgresadoValidation()
        {
            RuleFor(data => data.idUsuarioEgresado).NotEmpty().NotNull().GreaterThan(ValidatorHelper.ZERO);
            RuleFor(data => data.idConocimiento).NotEmpty().NotNull().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
