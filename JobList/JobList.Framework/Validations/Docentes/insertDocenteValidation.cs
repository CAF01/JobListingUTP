namespace JobList.Framework.Validations.Docentes
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;
    using JobList.Resources;

    public class insertDocenteValidation : AbstractValidator<insertDocenteRequest>
    {
        public insertDocenteValidation()
        {
            RuleFor(data => data.usuario).NotNull().WithMessage(ValidationResources.userRequired)
                .NotEmpty().WithMessage(ValidationResources.userNotEmpty)
                .MinimumLength(ValidatorHelper.FIVE).WithMessage(ValidationResources.userMinLength)
                .MaximumLength(ValidatorHelper.FIVETEEN).WithMessage(ValidationResources.userMaxLength);

            RuleFor(data => data.nombre).NotNull().WithMessage(ValidationResources.nameRequired)
                .NotEmpty().WithMessage(ValidationResources.nameNotEmpty)
                .MinimumLength(ValidatorHelper.TEN).WithMessage(ValidationResources.nameMinLength)
                .MaximumLength(ValidatorHelper.EIGHTYFIVE).WithMessage(ValidationResources.nameMaxLength);

            RuleFor(data => data.idTipo).Equal(ValidatorHelper.THREE);

            RuleFor(data => data.password).NotNull().WithMessage(ValidationResources.passwordRequired)
                 .NotEmpty().WithMessage(ValidationResources.passwordNotEmpty)
                 .MinimumLength(ValidatorHelper.SIX).WithMessage(ValidationResources.PassMinLength)
                 .MaximumLength(ValidatorHelper.THIRTY).WithMessage(ValidationResources.PassMaxLength);
        }
    }
}
