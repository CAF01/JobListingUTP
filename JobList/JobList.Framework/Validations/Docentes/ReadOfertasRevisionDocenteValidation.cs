namespace JobList.Framework.Validations.Docentes
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;

    public class ReadOfertasRevisionDocenteValidation : AbstractValidator<ReadOfertasRevisionDocenteRequest>
    {
        public ReadOfertasRevisionDocenteValidation()
        {
            RuleFor(data => data.idUsuarioDocente).NotNull().NotEmpty().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
