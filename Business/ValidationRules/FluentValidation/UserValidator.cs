using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            //User FirstName
            RuleFor(u => u.FirstName).NotEmpty().WithMessage("Kullanıcı İsmi Boş Olamaz!");
            RuleFor(u => u.FirstName).MinimumLength(2).WithMessage("Kullanıcı İsmi En Az 2 Karakter Olamlıdır.");

            //User LastName
            RuleFor(u => u.LastName).NotEmpty().WithMessage("Kullanıcı Soyismi Boş Olamaz!");
            RuleFor(u => u.LastName).MinimumLength(2).WithMessage("Kullanıcı Soyismi En Az 2 Karakter Olmalıdır");

            //User Email
            RuleFor(u => u.Email).NotEmpty().WithMessage("Kullanıcı E-Postası Boş Olamaz!");
            RuleFor(u => u.Email).Must(EmailIncludes).WithMessage("Geçersiz E-Posta");

            //User Password
            RuleFor(u => u.Password).NotEmpty().WithMessage("Parola Boş Olamaz!");
            RuleFor(u => u.Password).MinimumLength(6).WithMessage("Parola En Az 6 Karakter Olmalıdır");
            RuleFor(u => u.Password).MaximumLength(20).WithMessage("Parola En Fazla 20 Karakter Olmalıdır!");
        }
        private bool EmailIncludes(string email)
        {
            return email.Contains("@");
        }
    }
}
