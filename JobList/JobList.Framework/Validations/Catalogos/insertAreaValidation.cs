namespace JobList.Framework.Validations.Catalogos
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;
    using JobList.Resources;

    public class insertAreaValidation : AbstractValidator<InsertAreaRequest>
    {
        public insertAreaValidation()
        {
            RuleFor(data => data.descripcion).NotNull().WithMessage(ValidationResources.descriptionRequired)
                .NotEmpty().WithMessage(ValidationResources.descriptionNotEmpty)
                .MinimumLength(ValidatorHelper.FIVE).WithMessage($"{ValidationResources.descriptionMinLength}{ValidatorHelper.FIVE}")
                .MaximumLength(ValidatorHelper.SIXTY).WithMessage($"{ValidationResources.descriptionMaxLength}{ValidatorHelper.SIXTY}");

            RuleFor(data => data.idDivision).NotEmpty().NotNull().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
