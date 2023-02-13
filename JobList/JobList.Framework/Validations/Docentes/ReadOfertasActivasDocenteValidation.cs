using FluentValidation;
using JobList.Entities.Helpers;
using JobList.Entities.Requests;

namespace JobList.Framework.Validations.Docentes
{
    public class ReadOfertasActivasDocenteValidation : AbstractValidator<ReadOfertasActivasDocenteRequest>
    {
        public ReadOfertasActivasDocenteValidation()
        {
            RuleFor(data => data.idUsuarioDocente).NotNull().NotEmpty().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
