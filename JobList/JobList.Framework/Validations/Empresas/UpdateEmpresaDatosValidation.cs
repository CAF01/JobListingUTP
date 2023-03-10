namespace JobList.Framework.Validations.Empresas
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;
    using JobList.Resources;

    public class UpdateEmpresaDatosValidation : AbstractValidator<UpdateEmpresaDatosRequest>
    {
        public UpdateEmpresaDatosValidation()
        {
            RuleFor(data => data.idUsuario).NotEmpty().NotNull().GreaterThan(ValidatorHelper.ZERO);

            RuleFor(data => data.nombreEmpresa).NotNull().WithMessage(ValidationResources.companyRequired)
                .NotEmpty().WithMessage(ValidationResources.companyNotEmpty)
                .MinimumLength(ValidatorHelper.FIVE).WithMessage(ValidationResources.companyMinLength)
                .MaximumLength(ValidatorHelper.ONEHUNDRED).WithMessage(ValidationResources.companyMaxLength);

            RuleFor(data => data.RFC).NotNull().WithMessage(ValidationResources.RFCRequired)
               .NotEmpty().WithMessage(ValidationResources.RFCNotEmpty)
               .MinimumLength(ValidatorHelper.TWELVE).WithMessage(ValidationResources.RFCMinLength)
               .MaximumLength(ValidatorHelper.THIRTEEN).WithMessage(ValidationResources.RFCMaxLegth);

            RuleFor(data => data.actividadPrincipal).NotNull().WithMessage(ValidationResources.companyActivityRequired)
               .NotEmpty().WithMessage(ValidationResources.companyActivityNotEmpty)
               .MinimumLength(ValidatorHelper.FIVE).WithMessage(ValidationResources.companyActivityMinLength)
               .MaximumLength(ValidatorHelper.SEVENTYFIVE).WithMessage(ValidationResources.companyActivityMaxLength);

            RuleFor(data => data.domicilio).NotNull().WithMessage(ValidationResources.companyAddressRequired)
                .NotEmpty().WithMessage(ValidationResources.companyAddressNotEmpty)
                .MinimumLength(ValidatorHelper.TEN).WithMessage(ValidationResources.companyAddressMinLength)
                .MaximumLength(ValidatorHelper.ONEHUNDREDFIFTY).WithMessage(ValidationResources.companyAddressMaxLength);

            RuleFor(data => data.CP).NotNull().WithMessage(ValidationResources.CPRequired)
                 .NotEmpty().WithMessage(ValidationResources.CPNotEmpty)
                 .MinimumLength(ValidatorHelper.FIVE).WithMessage(ValidationResources.CPMinLength)
                 .MaximumLength(ValidatorHelper.FIVE).WithMessage(ValidationResources.CPMaxLength);

            RuleFor(data => data.telefonos).NotNull().WithMessage(ValidationResources.companyTelephoneRequired)
                .NotEmpty().WithMessage(ValidationResources.companyTelephoneNotEmpty)
                .MinimumLength(ValidatorHelper.TEN).WithMessage(ValidationResources.companyTelephoneMinLength)
                .MaximumLength(ValidatorHelper.FORTYFIVE).WithMessage(ValidationResources.companyTelephoneMaxLength);

            RuleFor(data => data.correoElectronico).NotNull().WithMessage(ValidationResources.companymailRequired)
                .NotEmpty().WithMessage(ValidationResources.companymailNotEmpty)
                .MinimumLength(ValidatorHelper.TEN).WithMessage(ValidationResources.companymailMinLength)
                .MaximumLength(ValidatorHelper.EIGHTYFIVE).WithMessage(ValidationResources.companymailMaxLength);

            RuleFor(data => data.acercaEmpresa).NotNull().WithMessage(ValidationResources.companyDescriptionRequired)
                .NotEmpty().WithMessage(ValidationResources.companyDescriptionNotEmpty)
                .MinimumLength(ValidatorHelper.ONEHUNDRED).WithMessage(ValidationResources.companyDescriptionMinLength)
                .MaximumLength(ValidatorHelper.FIVEHUNDRED).WithMessage(ValidationResources.companyDescriptionMaxLength);

            RuleFor(data => data.nombreResponsable).NotNull().WithMessage(ValidationResources.resTelephoneRequired)
                .NotEmpty().WithMessage(ValidationResources.resTelephoneNotEmpty)
                .MinimumLength(ValidatorHelper.SIX).WithMessage(ValidationResources.nameMinLength)
                .MaximumLength(ValidatorHelper.EIGHTYFIVE).WithMessage(ValidationResources.nameMaxLength);

            RuleFor(data => data.telefonoResponsable).NotNull().WithMessage(ValidationResources.resTelephoneRequired)
                .NotEmpty().WithMessage(ValidationResources.resTelephoneNotEmpty)
                .MinimumLength(ValidatorHelper.TEN).WithMessage(ValidationResources.resTelephoneMinLength)
                .MaximumLength(ValidatorHelper.TEN).WithMessage(ValidationResources.resTelephoneMaxLength);

            RuleFor(data => data.correoElectronicoResponsable).NotNull().WithMessage(ValidationResources.resMailRequired)
                .NotEmpty().WithMessage(ValidationResources.resMailNotEmpty)
                .MinimumLength(ValidatorHelper.TEN).WithMessage(ValidationResources.resMailMinLength)
                .MaximumLength(ValidatorHelper.EIGHTYFIVE).WithMessage(ValidationResources.resMailMaxLength);
        }
    }
}
