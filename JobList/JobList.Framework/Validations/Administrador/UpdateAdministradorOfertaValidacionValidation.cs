namespace JobList.Framework.Validations.Administrador
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;

    public class UpdateAdministradorOfertaValidacionValidation : AbstractValidator<UpdateAdministradorOfertaValidacionRequest>
    {
        public UpdateAdministradorOfertaValidacionValidation()
        {
            RuleFor(data => data.idOferta).NotNull().NotEmpty().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
