namespace JobList.Framework.Validations.Egresados
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;
    using JobList.Resources;

    public class UpdatePasswordEgresadoValidation : AbstractValidator<UpdatePasswordEgresadoRequest>
    {
        public UpdatePasswordEgresadoValidation()
        {
            RuleFor(data => data.idUsuario).NotNull().NotEmpty().GreaterThan(ValidatorHelper.ZERO);

            RuleFor(data => data.password).NotNull().WithMessage(ValidationResources.passwordRequired)
                 .NotEmpty().WithMessage(ValidationResources.passwordNotEmpty)
                 .MinimumLength(ValidatorHelper.SIX).WithMessage(ValidationResources.PassMinLength)
                 .MaximumLength(ValidatorHelper.THIRTY).WithMessage(ValidationResources.PassMaxLength);
        }
    }
}
