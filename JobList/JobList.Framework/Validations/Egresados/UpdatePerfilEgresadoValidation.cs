namespace JobList.Framework.Validations.Egresados
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;
    using JobList.Resources;

    public class UpdatePerfilEgresadoValidation : AbstractValidator<UpdatePerfilEgresadoRequest>
    {
        public UpdatePerfilEgresadoValidation()
        {
            RuleFor(data => data.idUsuario).NotNull().NotEmpty().GreaterThan(ValidatorHelper.ZERO);

            RuleFor(data => data.correo).NotNull().WithMessage(ValidationResources.mailRequired)
               .NotEmpty().WithMessage(ValidationResources.mailNotEmpty)
               .MinimumLength(ValidatorHelper.TEN).WithMessage(ValidationResources.mailMinLength)
               .MaximumLength(ValidatorHelper.EIGHTYFIVE).WithMessage(ValidationResources.mailMaxLength);

            RuleFor(data => data.edad).NotNull().WithMessage(ValidationResources.ageRequired)
               .NotEmpty().WithMessage(ValidationResources.ageNotEmpty);

            RuleFor(data => data.telefono)
                .MaximumLength(ValidatorHelper.TEN).WithMessage(ValidationResources.telephoneMaxLength);

            RuleFor(data => data.descripcionEgresado).NotNull().WithMessage(ValidationResources.descriptionRequired)
                 .NotEmpty().WithMessage(ValidationResources.descriptionNotEmpty)
                 .MinimumLength(ValidatorHelper.FIVETEEN).WithMessage($"{ValidationResources.descriptionMinLength}{ValidatorHelper.FIFTY}")
                 .MaximumLength(ValidatorHelper.FIVEHUNDRED).WithMessage($"{ValidationResources.descriptionMinLength}{ValidatorHelper.FIVEHUNDRED}");

            RuleFor(data => data.imgUrl).MaximumLength(ValidatorHelper.ONEHUNDRED).WithMessage(ValidationResources.imgUrlMaxLength);

            RuleFor(data => data.nombre).NotNull().WithMessage(ValidationResources.nameRequired)
                 .NotEmpty().WithMessage(ValidationResources.nameNotEmpty)
                 .MinimumLength(ValidatorHelper.THREE).WithMessage(ValidationResources.nameMinLength)
                 .MaximumLength(ValidatorHelper.EIGHTYFIVE).WithMessage(ValidationResources.nameMaxLength);

            RuleFor(data => data.apellido).NotNull().WithMessage(ValidationResources.lastNameRequired)
                 .NotEmpty().WithMessage(ValidationResources.lastNameNotEmpty)
                 .MinimumLength(ValidatorHelper.THREE).WithMessage(ValidationResources.lastNameMinLength)
                 .MaximumLength(ValidatorHelper.FIFTY).WithMessage(ValidationResources.lastNameMaxLength);

            RuleFor(data => data.generacion).NotNull().WithMessage(ValidationResources.generationRequired)
                .NotEmpty().WithMessage(ValidationResources.generationNotEmpty)
                .MinimumLength(ValidatorHelper.THREE).WithMessage(ValidationResources.generationMinLength)
                .MaximumLength(ValidatorHelper.FIFTY).WithMessage(ValidationResources.generationMaxLegth);
        }
    }
}
