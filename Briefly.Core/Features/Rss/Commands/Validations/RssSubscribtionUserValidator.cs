using Briefly.Core.Features.Rss.Commands.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Core.Features.Rss.Commands.Validations
{
    public class RssSubscribtionUserValidator : AbstractValidator<RssUserSubscribeCommand>
    {
        public RssSubscribtionUserValidator()
        {
            ApplyValidationRules();
        }
        private void ApplyValidationRules()
        {
            RuleFor(rss => rss.RssId)
                .NotEmpty().WithMessage("rss is required.");
        }
    }
}
