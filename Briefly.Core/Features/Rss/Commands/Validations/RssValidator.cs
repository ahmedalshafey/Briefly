using Briefly.Core.Features.Rss.Commands.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Briefly.Core.Features.Rss.Commands.Validations
{
    public class RssValidator : AbstractValidator<CreateRssCommand>
    {
        public RssValidator()
        {
            ApplyValidationRules();
        }
        private void ApplyValidationRules()
        {
            RuleFor(rss => rss.RssUrl)
                .NotEmpty().WithMessage("rss is required.");
        }
    }
}
