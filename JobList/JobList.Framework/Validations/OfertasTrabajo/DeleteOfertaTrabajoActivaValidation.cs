namespace JobList.Framework.Validations.OfertasTrabajo
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;

    public class DeleteOfertaTrabajoActivaValidation : AbstractValidator<DeleteOfertaTrabajoActivaRequest>
    {
        public DeleteOfertaTrabajoActivaValidation()
        {
            RuleFor(data => data.idOferta).NotEmpty().NotNull().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
