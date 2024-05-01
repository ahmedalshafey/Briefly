using Briefly.Core.Features.Auth.Commands.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Core.Features.Auth.Commands.Validations
{
    public class SendResetPasswordValidator : AbstractValidator<SendResetPasswordCommand>
    {
        public SendResetPasswordValidator()
        {
            ApplyValidationRules();
        }
        private void ApplyValidationRules()
        {
            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email address is required.")
                .EmailAddress().WithMessage("Invalid email address.");
        }
    }
}
