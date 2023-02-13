using FluentValidation;
using JobList.Entities.Helpers;
using JobList.Entities.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Framework.Validations.Docentes
{
    public class ReadOfertasRevisionDocenteValidation : AbstractValidator<ReadOfertasRevisionDocenteRequest>
    {
        public ReadOfertasRevisionDocenteValidation()
        {
            RuleFor(data => data.idUsuarioDocente).NotNull().NotEmpty().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
