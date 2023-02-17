namespace JobList.Framework.Validations.Catalogos
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;
    using JobList.Resources;

    public class InsertHabilidadValidation : AbstractValidator<InsertHabilidadRequest>  
    {
        public InsertHabilidadValidation()
        {
            RuleFor(data => data.descripcion).NotNull().WithMessage(ValidationResources.descriptionRequired)
                .NotEmpty().WithMessage(ValidationResources.descriptionNotEmpty)
                .MinimumLength(ValidatorHelper.FIVE).WithMessage($"{ValidationResources.descriptionMinLength}{ValidatorHelper.FIVE}")
                .MaximumLength(ValidatorHelper.EIGHTY).WithMessage($"{ValidationResources.descriptionMaxLength}{ValidatorHelper.EIGHTY}");
        }
    }
}
