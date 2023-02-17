namespace JobList.Framework.Validations.OfertasTrabajo
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;
    using JobList.Resources;

    public class InsertOfertaTrabajoExternaValidation : AbstractValidator<InsertOfertaTrabajoExternaRequest>
    {
        public InsertOfertaTrabajoExternaValidation()
        {
            RuleFor(data => data.descripcionPuesto).NotNull().WithMessage(ValidationResources.positionRequired)
                .NotEmpty().WithMessage(ValidationResources.positionNotEmpty)
                .MinimumLength(ValidatorHelper.FIVE).WithMessage(ValidationResources.positionMinLength)
                .MaximumLength(ValidatorHelper.EIGHTY).WithMessage(ValidationResources.positionMaxLength);

            RuleFor(data => data.idArea).NotEmpty().NotNull().GreaterThan(ValidatorHelper.ZERO);

            RuleFor(data => data.periodoContrato).NotNull().WithMessage(ValidationResources.contractPeriodRequired)
                .NotEmpty().WithMessage(ValidationResources.contractPeriodNotEmpty)
                .MinimumLength(ValidatorHelper.FIVE).WithMessage(ValidationResources.contractPeriodMinLength)
                .MaximumLength(ValidatorHelper.THIRTY).WithMessage(ValidationResources.contractPeriodMaxLenght);

            RuleFor(data => data.horarioTrabajo).NotNull().WithMessage(ValidationResources.workingHoursRequired)
                .NotEmpty().WithMessage(ValidationResources.workingHoursNotEmpty)
                .MinimumLength(ValidatorHelper.SEVEN).WithMessage(ValidationResources.workingHoursMinLength)
                .MaximumLength(ValidatorHelper.THIRTY).WithMessage(ValidationResources.workingHoursMaxLength);

            //RuleFor(data => data.sueldoMinEstimado).GreaterThan(ValidatorHelper.ZERO);

            //RuleFor(data => data.sueldoMaxEstimado).GreaterThan(ValidatorHelper.ZERO);

            RuleFor(data => data.lugar).NotNull().WithMessage(ValidationResources.placeRequired)
                .NotEmpty().WithMessage(ValidationResources.placeNotEmpty)
                .MinimumLength(ValidatorHelper.TEN).WithMessage(ValidationResources.placeMinLength)
                .MaximumLength(ValidatorHelper.ONEHUNDREDFIFTY).WithMessage(ValidationResources.placeMaxLength);

            RuleFor(data => data.habilidades)
                .NotNull().NotEmpty().WithMessage(ValidationResources.listSkillsRequired);

            RuleFor(data => data.conocimientos)
                .NotNull().NotEmpty().WithMessage(ValidationResources.listKnowledgeRequired);

            //RuleFor(data => data.responsabilidades)
            //    .NotNull().NotEmpty().WithMessage(ValidationResources.listResponsibilitiesRequired);

            RuleFor(data => data.idUsuario).NotEmpty().NotNull().GreaterThan(ValidatorHelper.ZERO);

            RuleFor(data => data.detallesContacto.empresa).NotNull().WithMessage(ValidationResources.companyRequired)
                .NotEmpty().WithMessage(ValidationResources.companyNotEmpty)
                .MinimumLength(ValidatorHelper.FIVE).WithMessage(ValidationResources.companyMinLength)
                .MaximumLength(ValidatorHelper.ONEHUNDRED).WithMessage(ValidationResources.companyMaxLength);

            RuleFor(data => data.detallesContacto.actividadEmpresa).NotNull().WithMessage(ValidationResources.companyActivityRequired)
                .NotEmpty().WithMessage(ValidationResources.companyActivityNotEmpty)
                .MinimumLength(ValidatorHelper.FIVE).WithMessage(ValidationResources.companyActivityMinLength)
                .MaximumLength(ValidatorHelper.SEVENTYFIVE).WithMessage(ValidationResources.companyActivityMaxLength);

            RuleFor(data => data.detallesContacto.domicilio).NotNull().WithMessage(ValidationResources.companyAddressRequired)
                .NotEmpty().WithMessage(ValidationResources.companyAddressNotEmpty)
                .MinimumLength(ValidatorHelper.TEN).WithMessage(ValidationResources.companyAddressMinLength)
                .MaximumLength(ValidatorHelper.ONEHUNDREDFIFTY).WithMessage(ValidationResources.companyAddressMaxLength);

            RuleFor(data => data.detallesContacto.CP).NotNull().WithMessage(ValidationResources.CPRequired)
                .NotEmpty().WithMessage(ValidationResources.CPNotEmpty)
                .MinimumLength(ValidatorHelper.FIVE).WithMessage(ValidationResources.CPMinLength)
                .MaximumLength(ValidatorHelper.FIVE).WithMessage(ValidationResources.CPMaxLength);

            RuleFor(data => data.detallesContacto.telefonos).NotNull().WithMessage(ValidationResources.companyTelephoneRequired)
                .NotEmpty().WithMessage(ValidationResources.companyTelephoneNotEmpty)
                .MinimumLength(ValidatorHelper.TEN).WithMessage(ValidationResources.companyTelephoneMinLength)
                .MaximumLength(ValidatorHelper.FORTYFIVE).WithMessage(ValidationResources.companyTelephoneMaxLength);

            RuleFor(data => data.detallesContacto.correoEmpresa).NotNull().WithMessage(ValidationResources.companymailRequired)
                .NotEmpty().WithMessage(ValidationResources.companymailNotEmpty)
                .MinimumLength(ValidatorHelper.TEN).WithMessage(ValidationResources.companymailMinLength)
                .MaximumLength(ValidatorHelper.EIGHTYFIVE).WithMessage(ValidationResources.companymailMaxLength);

            RuleFor(data => data.detallesContacto.descripcionEmpresa).NotNull().WithMessage(ValidationResources.companyDescriptionRequired)
                .NotEmpty().WithMessage(ValidationResources.companyDescriptionNotEmpty)
                .MinimumLength(ValidatorHelper.ONEHUNDRED).WithMessage(ValidationResources.companyDescriptionMinLength)
                .MaximumLength(ValidatorHelper.FIVEHUNDRED).WithMessage(ValidationResources.companyDescriptionMaxLength);

            RuleFor(data => data.detallesContacto.nombreResponsable).NotNull().WithMessage(ValidationResources.resTelephoneRequired)
                .NotEmpty().WithMessage(ValidationResources.resTelephoneNotEmpty)
                .MinimumLength(ValidatorHelper.TEN).WithMessage(ValidationResources.resTelephoneMinLength)
                .MaximumLength(ValidatorHelper.TEN).WithMessage(ValidationResources.resTelephoneMaxLength);

            RuleFor(data => data.detallesContacto.telefonoResponsable).NotNull().WithMessage(ValidationResources.resTelephoneRequired)
                .NotEmpty().WithMessage(ValidationResources.resTelephoneNotEmpty)
                .MinimumLength(ValidatorHelper.TEN).WithMessage(ValidationResources.resTelephoneMinLength)
                .MaximumLength(ValidatorHelper.TEN).WithMessage(ValidationResources.resTelephoneMaxLength);

            RuleFor(data => data.detallesContacto.correoResponsable).NotNull().WithMessage(ValidationResources.resMailRequired)
                .NotEmpty().WithMessage(ValidationResources.resMailNotEmpty)
                .MinimumLength(ValidatorHelper.TEN).WithMessage(ValidationResources.resMailMinLength)
                .MaximumLength(ValidatorHelper.EIGHTYFIVE).WithMessage(ValidationResources.resMailMaxLength);

            RuleFor(data => data.detallesContacto.imgUrl)
                .MaximumLength(ValidatorHelper.TEN).WithMessage(ValidationResources.imgUrlMaxLength);
        }
    }
}
