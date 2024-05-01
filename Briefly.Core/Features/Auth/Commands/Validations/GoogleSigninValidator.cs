using Briefly.Core.Features.Auth.Commands.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Core.Features.Auth.Commands.Validations
{
    public class GoogleSigninValidator : AbstractValidator<GoogleSigninCommand>
    {
        public GoogleSigninValidator()
        {
            ApplyRoles();
        }
        public void ApplyRoles()
        {
            RuleFor(x => x.IdToken).NotEmpty().WithMessage("Idtoken is required");
        }
    }
}
