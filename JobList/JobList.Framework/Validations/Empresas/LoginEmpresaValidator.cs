using FluentValidation;
using JobList.Entities.Helpers;
using JobList.Entities.Requests;
using JobList.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobList.Framework.Validations.Empresas
{
    public class LoginEmpresaValidator : AbstractValidator<LoginEmpresaRequest>
    {
        public LoginEmpresaValidator()
        {
            RuleFor(data => data.usuario).NotNull().WithMessage(ValidationResources.userRequired).NotEmpty()
                .WithMessage(ValidationResources.userNotEmpty).MinimumLength(ValidatorHelper.FIVE).WithMessage(ValidationResources.userMinLength)
                .MaximumLength(ValidatorHelper.FIVETEEN).WithMessage(ValidationResources.userMaxLength);

            RuleFor(data => data.usuario).Must(x => !x.Contains(ValidatorHelper.WHITESPACE)).WithMessage(ValidationResources.noWhiteSpace);

            RuleFor(data => data.password).NotNull().WithMessage(ValidationResources.passwordRequired)
                    .NotEmpty().WithMessage(ValidationResources.passwordNotEmpty)
                    .MinimumLength(ValidatorHelper.SIX).WithMessage(ValidationResources.PassMinLength)
                    .MaximumLength(ValidatorHelper.THIRTY).WithMessage(ValidationResources.PassMaxLength);
        }
    }
}
