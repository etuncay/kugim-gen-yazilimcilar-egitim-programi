using FluentValidation;
using Haber.Models.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Core.Validator
{
    public class KategoriRequestValidator : AbstractValidator<KategoriRequestViewModel>
    {
        public KategoriRequestValidator()
        {
            RuleFor(c => c.Ad).NotEmpty().NotNull().WithMessage("zorunludur");
            RuleFor(c => c.Aciklama).Length(0, 500).WithMessage("500 karakterden fazla olamaz");
        }
    }
}
