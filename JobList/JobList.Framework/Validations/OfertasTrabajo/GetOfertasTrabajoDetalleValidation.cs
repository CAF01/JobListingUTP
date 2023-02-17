namespace JobList.Framework.Validations.OfertasTrabajo
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;

    public class GetOfertasTrabajoDetalleValidation : AbstractValidator<GetOfertasTrabajoDetalleRequest>
    {
        public GetOfertasTrabajoDetalleValidation()
        {
            RuleFor(data => data.idOferta).NotEmpty().NotNull().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
