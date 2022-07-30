using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            // FirstName
            RuleFor(user => user.FirstName).NotEmpty().WithMessage("Kullanıcı İsmi Boş Olamaz!");
            RuleFor(user => user.FirstName).MinimumLength(2).WithMessage("Kullanıcı İsmi En Az 2 Karakter Olamlıdır.");
            RuleFor(user => user.FirstName).Must(ControlName).WithMessage("Kullanıcı İsmi Geçersiz Karakter İçeriyor");

            // LastName
            RuleFor(user => user.LastName).NotEmpty().WithMessage("Kullanıcı Soyismi Boş Olamaz!");
            RuleFor(user => user.LastName).MinimumLength(2).WithMessage("Kullanıcı Soyismi En Az 2 Karakter Olmalıdır");

            // Email
            RuleFor(user => user.Email).NotEmpty().WithMessage("Kullanıcı E-Postası Boş Olamaz!");
            RuleFor(user => user.Email).Must(ControlEmail).WithMessage("Geçersiz E-Posta");

            // PhoneNumber
            RuleFor(user => user.PhoneNumber).NotEmpty().WithMessage("Telefon Numarası Boş Olamaz");
            RuleFor(user => user.PhoneNumber).Must(ControlPhoneNumber).WithMessage("Geçersiz Telefon Numarası");
            RuleFor(user => user.PhoneNumber).Must(StartWith).WithMessage("Telefon numarası 0(sıfır) ile başlayamaz");

        }

        // ControlName
        private bool ControlName(string arg)
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

        // ControlEmail
        private bool ControlEmail(string arg)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
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

        
        // ControlPhoneNumber
        private bool ControlPhoneNumber(string arg)
        {
            Regex regex = new Regex(@"^[1-9]{10}$");
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

        private bool StartWith(string arg)
        {
            var result = arg.StartsWith('0');
            if (arg.StartsWith('0'))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
