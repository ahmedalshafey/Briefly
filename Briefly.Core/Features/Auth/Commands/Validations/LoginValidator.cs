using Briefly.Core.Features.Auth.Commands.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Core.Features.Auth.Commands.Validations
{
    public class LoginValidator : AbstractValidator<LoginCommand>
    {
        public LoginValidator()
        {
            ApplyValidationRules();
        }
        private void ApplyValidationRules()
        {
            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("email is required");

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("password is required");
        }
    }
}
