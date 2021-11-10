using FluentValidation;
using Haber.Models.ViewModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haber.Core.Validator
{
    public class KullaniciRequestValidator : AbstractValidator<KullaniciRequestViewModel>
    {
        public KullaniciRequestValidator()
        {
            RuleFor(c => c.Ad).NotEmpty().WithMessage("zorunludur.");
            RuleFor(c => c.Soyad).NotEmpty().WithMessage("zorunludur.");
            RuleFor(c => c.Eposta).NotEmpty().EmailAddress().WithMessage("Geçerli bir eposta giriniz");
            RuleFor(c => c.KullaniciAdi).NotEmpty().WithMessage("zorunludur");
            RuleFor(c => c.Sifre).NotEmpty().WithMessage("zorunludur");
        }
    }
}
