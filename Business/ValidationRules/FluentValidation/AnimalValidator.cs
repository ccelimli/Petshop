using Entites.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class AnimalValidator : AbstractValidator<Animal>
    {
        public AnimalValidator()
        {
            RuleFor(a => a.AnimalName).NotEmpty().WithMessage("Pet ismi Boş olamaz");
            RuleFor(a => a.AnimalName).MinimumLength(2).WithMessage("Pet İsmi En Az 2 Karakter Olmalıdır!");
        }
    }
}
