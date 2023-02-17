namespace JobList.Framework.Validations.Catalogos
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;
    using JobList.Resources;

    public class UpdateConocimientoValidation : AbstractValidator<UpdateConocimientoRequest>
    {
        public UpdateConocimientoValidation()
        {
            RuleFor(data => data.nuevaDescripcion).NotNull().WithMessage(ValidationResources.descriptionRequired)
                .NotEmpty().WithMessage(ValidationResources.descriptionNotEmpty)
                .MinimumLength(ValidatorHelper.FIVE).WithMessage($"{ValidationResources.descriptionMinLength}{ValidatorHelper.FIVE}")
                .MaximumLength(ValidatorHelper.ONEHUNDREDFIFTY).WithMessage($"{ValidationResources.descriptionMaxLength}{ValidatorHelper.ONEHUNDREDFIFTY}");

            RuleFor(data => data.idConocimiento).NotNull().NotEmpty().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
