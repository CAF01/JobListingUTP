using FluentValidation;
using JobList.Entities.Helpers;
using JobList.Entities.Requests;

namespace JobList.Framework.Validations.Docentes
{
    public class ReadHistorialOfertasDocenteValidation : AbstractValidator<ReadHistorialOfertasDocenteRequest>
    {
        public ReadHistorialOfertasDocenteValidation()
        {
            RuleFor(data => data.idUsuarioDocente).NotNull().NotEmpty().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
