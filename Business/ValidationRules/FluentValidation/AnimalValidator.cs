using Entites.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class AnimalValidator : AbstractValidator<Animal>
    {
        public AnimalValidator()
        {
            RuleFor(animal => animal.AnimalName).NotEmpty().WithMessage("Pet ismi Boş olamaz");
            RuleFor(animal => animal.AnimalName).MinimumLength(2).WithMessage("Pet İsmi En Az 2 Karakter Olmalıdır!");
            RuleFor(animal => animal.AnimalName).Must(ControlAnimalName).WithMessage("Geçersiz Pet İsmi!");
        }
        // ControlName
        private bool ControlAnimalName(string arg)
        {
            Regex regex = new Regex(@"^[A-ZİĞÜŞÖÇ][a-zA-ZğüşöçıİĞÜŞÖÇ]*$");
            var result = regex.Match(arg);
            if (result.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
