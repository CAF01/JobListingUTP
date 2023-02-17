namespace JobList.Framework.Validations.Catalogos
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;
    using JobList.Resources;

    public class UpdateHabilidadValidation : AbstractValidator<UpdateHabilidadRequest>
    {
        public UpdateHabilidadValidation()
        {
            RuleFor(data => data.nuevaDescripcion).NotNull().WithMessage(ValidationResources.descriptionRequired)
                .NotEmpty().WithMessage(ValidationResources.descriptionNotEmpty)
                .MinimumLength(ValidatorHelper.FIVE).WithMessage($"{ValidationResources.descriptionMinLength}{ValidatorHelper.FIVE}")
                .MaximumLength(ValidatorHelper.EIGHTY).WithMessage($"{ValidationResources.descriptionMaxLength}{ValidatorHelper.EIGHTY}");

            RuleFor(data => data.idHabilidad).NotNull().NotEmpty().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
