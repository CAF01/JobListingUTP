namespace JobList.Framework.Validations.Egresados
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;
    using JobList.Resources;

    public class InsertEgresadoExpLaboralValidation : AbstractValidator<InsertEgresadoExpLaboralRequest>
    {
        public InsertEgresadoExpLaboralValidation()
        {
            RuleFor(data => data.empresa).NotNull().WithMessage(ValidationResources.companyRequired)
                .NotEmpty().WithMessage(ValidationResources.companyNotEmpty)
                .MinimumLength(ValidatorHelper.FIVE).WithMessage(ValidationResources.companyMinLength)
                .MaximumLength(ValidatorHelper.ONEHUNDRED).WithMessage(ValidationResources.companyMaxLength);

            RuleFor(data => data.cargo).NotNull().WithMessage(ValidationResources.positionRequired)
                .NotEmpty().WithMessage(ValidationResources.positionNotEmpty)
                .MinimumLength(ValidatorHelper.FIVE).WithMessage(ValidationResources.positionMinLength)
                .MaximumLength(ValidatorHelper.EIGHTY).WithMessage(ValidationResources.positionMaxLength);


            RuleFor(data => data.periodo).NotNull().WithMessage(ValidationResources.periodRequired)
                 .NotEmpty().WithMessage(ValidationResources.periodNotEmpty)
                 .MinimumLength(ValidatorHelper.FOUR).WithMessage(ValidationResources.periodMinLength)
                 .MaximumLength(ValidatorHelper.SIXTY).WithMessage(ValidationResources.periodMaxLength);

            RuleFor(data => data.idUsuarioEgresado).NotNull().NotEmpty().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
