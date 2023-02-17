namespace JobList.Framework.Validations.OfertasTrabajo
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;
    using JobList.Resources;

    public class InsertOfertaTrabajoValidation : AbstractValidator<InsertOfertaTrabajoRequest>
    {
        public InsertOfertaTrabajoValidation()
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

            //RuleFor(data => data.suelodMaxEstimado).GreaterThan(ValidatorHelper.ZERO);

            RuleFor(data => data.lugar).NotNull().WithMessage(ValidationResources.placeRequired)
                .NotEmpty().WithMessage(ValidationResources.placeNotEmpty)
                .MinimumLength(ValidatorHelper.TEN).WithMessage(ValidationResources.placeMinLength)
                .MaximumLength(ValidatorHelper.ONEHUNDREDFIFTY).WithMessage(ValidationResources.placeMaxLength);

            RuleFor(data => data.habilidades)
                .NotNull().NotEmpty().WithMessage(ValidationResources.listSkillsRequired);

            RuleFor(data => data.conocimientos)
                .NotNull().NotEmpty().WithMessage(ValidationResources.listKnowledgeRequired);

            RuleFor(data => data.responsabilidades)
                .NotNull().NotEmpty().WithMessage(ValidationResources.listResponsibilitiesRequired);

            RuleFor(data => data.idUsuarioEmpresa).NotEmpty().NotNull().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
