using Entites.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("ürün ismi boş olamaz.");
            RuleFor(p => p.ProductName).MinimumLength(3).WithMessage("Ürün ismini en az 3 karakter olmalıdır.");
            RuleFor(p => p.UnitPrice).NotEmpty().WithMessage("Ürün fiyatı boş kalamaz.");
            RuleFor(p => p.UnitPrice).GreaterThan(0).WithMessage("Ürün fiyatı 0'dan fazla olmalıdır.");
        }
    }
}
