namespace JobList.Framework.Validations.Empresas
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;
    using JobList.Resources;

    public class InsertEmpresaValidation : AbstractValidator<InsertEmpresaRequest>
    {
        public InsertEmpresaValidation()
        {
            RuleFor(data => data.usuario).NotNull().WithMessage(ValidationResources.userRequired)
                .NotEmpty().WithMessage(ValidationResources.userNotEmpty)
                .MinimumLength(ValidatorHelper.FIVE).WithMessage(ValidationResources.userMinLength)
                .MaximumLength(ValidatorHelper.FIVETEEN).WithMessage(ValidationResources.userMaxLength);

            RuleFor(data => data.password).NotNull().WithMessage(ValidationResources.passwordRequired)
                 .NotEmpty().WithMessage(ValidationResources.passwordNotEmpty)
                 .MinimumLength(ValidatorHelper.SIX).WithMessage(ValidationResources.PassMinLength)
                 .MaximumLength(ValidatorHelper.THIRTY).WithMessage(ValidationResources.PassMaxLength);

            RuleFor(data => data.nombreResponsable).NotNull().WithMessage(ValidationResources.nameRequired)
               .NotEmpty().WithMessage(ValidationResources.nameNotEmpty)
               .MinimumLength(ValidatorHelper.TEN).WithMessage(ValidationResources.nameMinLength)
               .MaximumLength(ValidatorHelper.EIGHTYFIVE).WithMessage(ValidationResources.nameMaxLength);

            RuleFor(data => data.nombreEmpresa).NotNull().WithMessage(ValidationResources.companyRequired)
               .NotEmpty().WithMessage(ValidationResources.companyNotEmpty)
               .MinimumLength(ValidatorHelper.FIVE).WithMessage(ValidationResources.companyMinLength)
               .MaximumLength(ValidatorHelper.ONEHUNDRED).WithMessage(ValidationResources.companyMaxLength);
        }
    }
}
