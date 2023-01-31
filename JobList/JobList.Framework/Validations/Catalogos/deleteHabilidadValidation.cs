namespace JobList.Framework.Validations.Catalogos
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;

    public class deleteHabilidadValidation : AbstractValidator<DeleteHabilidadRequest>
    {
        public deleteHabilidadValidation()
        {
            RuleFor(data => data.idHabilidad).NotEmpty().NotNull().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
