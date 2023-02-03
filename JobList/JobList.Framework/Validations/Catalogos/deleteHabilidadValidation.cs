namespace JobList.Framework.Validations.Catalogos
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;

    public class DeleteHabilidadValidation : AbstractValidator<DeleteHabilidadRequest>
    {
        public DeleteHabilidadValidation()
        {
            RuleFor(data => data.idHabilidad).NotEmpty().NotNull().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
