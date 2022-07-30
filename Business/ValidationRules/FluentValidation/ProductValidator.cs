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
            RuleFor(product => product.ProductName).NotEmpty().WithMessage("ürün ismi boş olamaz.");
            RuleFor(product => product.ProductName).MinimumLength(3).WithMessage("Ürün ismini en az 3 karakter olmalıdır.");
            RuleFor(product => product.UnitPrice).NotEmpty().WithMessage("Ürün fiyatı boş kalamaz.");
            RuleFor(product => product.UnitPrice).GreaterThan(0).WithMessage("Ürün fiyatı 0'dan fazla olmalıdır.");
        }
    }
}
