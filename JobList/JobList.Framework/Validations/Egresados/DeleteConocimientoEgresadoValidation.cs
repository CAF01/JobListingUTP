namespace JobList.Framework.Validations.Egresados
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;

    public class DeleteConocimientoEgresadoValidation : AbstractValidator<DeleteConocimientoEgresadoRequest>
    {
        public DeleteConocimientoEgresadoValidation()
        {
            RuleFor(data => data.idUsuarioEgresado).NotEmpty().NotNull().GreaterThan(ValidatorHelper.ZERO);
            RuleFor(data => data.idConocimiento).NotEmpty().NotNull().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
