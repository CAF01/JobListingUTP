namespace JobList.Framework.Validations.Docentes
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;

    public class UpdateEstadoPostulacionValidation : AbstractValidator<UpdateEstadoPostulacionRequest>
    {
        public UpdateEstadoPostulacionValidation()
        {
            RuleFor(data => data.idPostulacion).NotNull().NotEmpty().GreaterThan(ValidatorHelper.ZERO);
            RuleFor(data => data.accion).NotNull().NotEmpty().GreaterThan(ValidatorHelper.ZERO).LessThanOrEqualTo(ValidatorHelper.TWO);
        }
    }
}