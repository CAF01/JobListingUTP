namespace JobList.Framework.Validations.Catalogos
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;

    public class deleteConocimientoValidation : AbstractValidator<DeleteConocimientoRequest>
    {
        public deleteConocimientoValidation()
        {
            RuleFor(data => data.idConocimiento).NotEmpty().NotNull().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
