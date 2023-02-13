using FluentValidation;
using JobList.Entities.Helpers;
using JobList.Entities.Requests;

namespace JobList.Framework.Validations.Docentes
{
    public class ReadPostulacionesOfertaDocenteValidation : AbstractValidator<ReadPostulacionesOfertaRequest>
    {
        public ReadPostulacionesOfertaDocenteValidation()
        {
            RuleFor(data => data.idOferta).NotNull().NotEmpty().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
