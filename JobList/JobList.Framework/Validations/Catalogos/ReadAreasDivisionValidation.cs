namespace JobList.Framework.Validations.Catalogos
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;

    public class ReadAreasDivisionValidation : AbstractValidator<ReadAreasDivisionRequest>
    {
        public ReadAreasDivisionValidation()
        {
            RuleFor(data=>data.idDivision).NotNull().NotEmpty().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
