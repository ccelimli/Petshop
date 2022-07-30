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
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(category => category.CategoryName).NotEmpty().WithMessage("Kategori İsmi Boş Olamaz!");
            RuleFor(category => category.CategoryName).MinimumLength(2).WithMessage("Kategori İsmi En Az 2 Karakterden Oluşmalıdır!");
            RuleFor(category => category.CategoryName).Must(ControlCategoryName).WithMessage("Geçersiz Kategori İsmi!");
        }

        // ControlName
        private bool ControlCategoryName(string arg)
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
