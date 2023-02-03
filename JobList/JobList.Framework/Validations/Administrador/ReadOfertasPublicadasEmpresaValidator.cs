using FluentValidation;
using JobList.Entities.Helpers;
using JobList.Entities.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Framework.Validations.Administrador
{
    public class ReadOfertasPublicadasEmpresaValidator : AbstractValidator<ReadOfertasPublicadasEmpresaRequest>
    {
        public ReadOfertasPublicadasEmpresaValidator()
        {
            RuleFor(data => data.idUsuarioEmpresa).NotNull().NotEmpty().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
