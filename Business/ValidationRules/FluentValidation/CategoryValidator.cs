using Entites.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.CategoryName).NotEmpty().WithMessage("Kategori İsmi Boş Olamaz!");
            RuleFor(c => c.CategoryName).MinimumLength(2).WithMessage("Kategori İsmi En Az 2 Karakterden Oluşmalıdır");
        }
    }
}
