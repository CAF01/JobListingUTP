namespace JobList.Framework.Validations.Egresados
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;

    public class DeleteEgresadoExpLaboralValidation : AbstractValidator<DeleteEgresadoExpLaboralRequest>
    {
        public DeleteEgresadoExpLaboralValidation()
        {
            RuleFor(data => data.idExperiencia).NotEmpty().NotNull().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
