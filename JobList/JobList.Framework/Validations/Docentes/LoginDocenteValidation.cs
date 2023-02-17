namespace JobList.Framework.Validations.Docentes
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;
    using JobList.Resources;

    public class LoginDocenteValidation : AbstractValidator<LoginDocenteRequest>
    {
        public LoginDocenteValidation()
        {
            RuleFor(data => data.usuario).NotNull().WithMessage(ValidationResources.userRequired).NotEmpty()
                .WithMessage(ValidationResources.userNotEmpty)
                .MinimumLength(ValidatorHelper.FOUR).WithMessage(ValidationResources.userMinLength)
                .MaximumLength(ValidatorHelper.FIVETEEN).WithMessage(ValidationResources.userMaxLength);

            RuleFor(data => data.usuario).Must(x => !x.Contains(ValidatorHelper.WHITESPACE)).WithMessage(ValidationResources.noWhiteSpace);

            RuleFor(data => data.password).NotNull().WithMessage(ValidationResources.passwordRequired)
                    .NotEmpty().WithMessage(ValidationResources.passwordNotEmpty)
                    .MinimumLength(ValidatorHelper.FOUR).WithMessage(ValidationResources.PassMinLength)
                    .MaximumLength(ValidatorHelper.THIRTY).WithMessage(ValidationResources.PassMaxLength);
        }        
    }
}
