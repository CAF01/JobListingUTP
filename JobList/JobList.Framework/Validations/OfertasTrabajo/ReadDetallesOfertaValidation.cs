namespace JobList.Framework.Validations.OfertasTrabajo
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;

    public class ReadDetallesOfertaValidation : AbstractValidator<ReadDetallesOfertaRequest>
    {
        public ReadDetallesOfertaValidation()
        {
            RuleFor(data => data.idOferta).NotEmpty().NotNull().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
