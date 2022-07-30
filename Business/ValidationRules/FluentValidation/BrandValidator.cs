using Entites.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(brand => brand.BrandName).NotEmpty().WithMessage("Marka İsmi Boş Olamaz");
            RuleFor(brand => brand.BrandName).MinimumLength(2).WithMessage("Marka İsmi En Az 2 Karakter Olmalıdır.");
        }
    }
}
