using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidatior : AbstractValidator<Contact>
    {
        public ContactValidatior()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("İsmi boş geçemezsiniz");
            RuleFor(X => X.UserMail).NotEmpty().WithMessage("Mail kısmını boş geçemezsiniz");
            RuleFor(X => X.Subject).NotEmpty().WithMessage("Konu kısmını boş geçemezsiniz");
            RuleFor(X => X.Message).NotEmpty().WithMessage("Mesaj kısmını boş geçemezsiniz");
            RuleFor(X => X.UserName).MinimumLength(3).WithMessage("En az 3 Karakter girilmeli");
            RuleFor(X => X.UserName).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla giriş yapmayınız");
            RuleFor(X => X.UserMail).MinimumLength(3).WithMessage("En az 3 Karakter girilmeli");
            RuleFor(X => X.Subject).MinimumLength(3).WithMessage("En az 3 Karakter girilmeli");
            RuleFor(X => X.Subject).MaximumLength(100).WithMessage("Lütfen 50 karakterden fazla giriş yapmayınız");
            RuleFor(X => X.UserMail).EmailAddress().WithMessage("Lütfen mail adresi giriniz");

        }
    }
}
