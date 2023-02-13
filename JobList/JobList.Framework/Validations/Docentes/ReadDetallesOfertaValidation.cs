using FluentValidation;
using JobList.Entities.Helpers;
using JobList.Entities.Requests;

namespace JobList.Framework.Validations.Docentes
{
    public class ReadDetallesOfertaValidation : AbstractValidator<ReadDetallesOfertaRequest>
    {
        public ReadDetallesOfertaValidation()
        {
            RuleFor(data => data.idOferta).NotNull().NotEmpty().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
