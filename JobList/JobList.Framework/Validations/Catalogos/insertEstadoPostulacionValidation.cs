namespace JobList.Framework.Validations.Catalogos
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;
    using JobList.Resources;

    public class insertEstadoPostulacionValidation : AbstractValidator<InsertEstadoPostulacionRequest>
    {
        public insertEstadoPostulacionValidation()
        {
            RuleFor(data => data.descripcion).NotNull().WithMessage(ValidationResources.descriptionRequired)
                .NotEmpty().WithMessage(ValidationResources.descriptionNotEmpty)
                .MinimumLength(ValidatorHelper.THREE).WithMessage($"{ValidationResources.descriptionMinLength}{ValidatorHelper.THREE}")
                .MaximumLength(ValidatorHelper.FORTYFIVE).WithMessage($"{ValidationResources.descriptionMaxLength}{ValidatorHelper.FORTYFIVE}");
        }
    }
}
