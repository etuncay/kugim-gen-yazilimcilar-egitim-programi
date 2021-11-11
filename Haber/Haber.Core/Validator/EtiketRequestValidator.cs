using FluentValidation;
using Haber.Models.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Core.Validator
{
    public class EtiketRequestValidator : AbstractValidator<EtiketRequestViewModel>
    {
        public EtiketRequestValidator()
        {
            RuleFor(c => c.Ad).NotEmpty().NotNull().WithMessage("zorunludur");
        }
    }
}
