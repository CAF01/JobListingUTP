using FluentValidation;
using JobList.Entities.Helpers;
using JobList.Entities.Requests;

namespace JobList.Framework.Validations.Egresados
{
    public class ReadOfertasActivasFiltroEgresadoValidation : AbstractValidator<ReadOfertasActivasFiltroEgresadoRequest>
    {
        public ReadOfertasActivasFiltroEgresadoValidation()
        {
            RuleFor(data => data.idUsuarioEgresado).NotNull().NotEmpty().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
