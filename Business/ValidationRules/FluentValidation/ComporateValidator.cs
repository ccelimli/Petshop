using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ComporateValidator :AbstractValidator<Comporate>
    {
        public ComporateValidator()
        {
            RuleFor(comporate => comporate.CompanyName).NotEmpty().WithMessage("Şirket İsmi Boş Olamaz!");
            RuleFor(comporate => comporate.CompanyAddress).NotEmpty().WithMessage("Şirket Adresi Boş olamaz");
        }
    }
}
