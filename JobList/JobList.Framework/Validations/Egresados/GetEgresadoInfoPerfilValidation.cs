﻿namespace JobList.Framework.Validations.Egresados
{
    using FluentValidation;
    using JobList.Entities.Helpers;
    using JobList.Entities.Requests;

    public class GetEgresadoInfoPerfilValidation : AbstractValidator<GetEgresadoInfoPerfilRequest>
    {
        public GetEgresadoInfoPerfilValidation()
        {
            RuleFor(data => data.idUsuario).NotNull().NotEmpty().GreaterThan(ValidatorHelper.ZERO);
        }
    }
}
