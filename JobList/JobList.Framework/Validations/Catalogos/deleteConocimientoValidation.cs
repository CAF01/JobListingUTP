namespace JobList.Framework.Validations.Catalogos
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;

    public class DeleteConocimientoValidation : AbstractValidator<DeleteConocimientoRequest>
    {
        public DeleteConocimientoValidation()
        {
            RuleFor(data => data.idConocimiento).NotEmpty().NotNull().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
