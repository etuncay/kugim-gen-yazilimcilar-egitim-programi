using FluentValidation;
using Haber.Models.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Core.Validator
{
    public class IcerikRequestValidator : AbstractValidator<IcerikRequestViewModel>
    {
        public IcerikRequestValidator()
        {
            RuleFor(c => c.Baslik).NotEmpty().NotNull().WithMessage("zorunludur");
            RuleFor(c => c.IcerikTipi).NotEmpty().NotNull().WithMessage("zorunludur");
            RuleFor(c => c.KategoriId).NotEmpty().NotNull().WithMessage("zorunludur");
            RuleFor(c => c.Govde).NotEmpty().NotNull().WithMessage("zorunludur");
        }
    }
}
