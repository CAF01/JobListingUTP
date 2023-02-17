namespace JobList.Framework.Validations.Egresados
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;
    using JobList.Resources;

    public class InsertEgresadoValidation : AbstractValidator<InsertEgresadoRequest>
    {
        public InsertEgresadoValidation()
        {
            RuleFor(data => data.usuario).NotNull().WithMessage(ValidationResources.userRequired)
               .NotEmpty().WithMessage(ValidationResources.userNotEmpty)
               .MinimumLength(ValidatorHelper.FIVE).WithMessage(ValidationResources.userMinLength)
               .MaximumLength(ValidatorHelper.FIVETEEN).WithMessage(ValidationResources.userMaxLength);

            RuleFor(data => data.password).NotNull().WithMessage(ValidationResources.passwordRequired)
                .NotEmpty().WithMessage(ValidationResources.passwordNotEmpty)
                .MinimumLength(ValidatorHelper.SIX).WithMessage(ValidationResources.PassMinLength)
                .MaximumLength(ValidatorHelper.THIRTY).WithMessage(ValidationResources.PassMaxLength);


            RuleFor(data => data.nombre).NotNull().WithMessage(ValidationResources.nameRequired)
                 .NotEmpty().WithMessage(ValidationResources.nameNotEmpty)
                 .MinimumLength(ValidatorHelper.THREE).WithMessage(ValidationResources.graduatedNameMinLength)
                 .MaximumLength(ValidatorHelper.EIGHTYFIVE).WithMessage(ValidationResources.graduatedNameMaxLength);

            RuleFor(data => data.apellido).NotNull().WithMessage(ValidationResources.lastNameRequired)
                 .NotEmpty().WithMessage(ValidationResources.lastNameNotEmpty)
                 .MinimumLength(ValidatorHelper.THREE).WithMessage(ValidationResources.lastNameMinLength)
                 .MaximumLength(ValidatorHelper.FIFTY).WithMessage(ValidationResources.lastNameMaxLength);

            RuleFor(data => data.idArea).NotNull().NotEmpty().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
