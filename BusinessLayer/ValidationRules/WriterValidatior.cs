using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidatior : AbstractValidator<Writer>
    {
        public WriterValidatior()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("İsmi boş geçemezsiniz");
            RuleFor(X => X.WriterSurname).NotEmpty().WithMessage("soyisim kısmını boş geçemezsiniz");
            RuleFor(X => X.WriterMail).NotEmpty().WithMessage("mail kısmını boş geçemezsiniz");
            RuleFor(X => X.WriterName).MinimumLength(3).WithMessage("En az 3 Karakter girilmeli");
            RuleFor(X => X.WriterName).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla giriş yapmayınız");
            RuleFor(X => X.WriterSurname).MinimumLength(3).WithMessage("En az 3 Karakter girilmeli");
            RuleFor(X => X.WriterSurname).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla giriş yapmayınız");
            RuleFor(X => X.About).MinimumLength(3).WithMessage("En az 3 Karakter girilmeli");
            RuleFor(X => X.About).MaximumLength(100).WithMessage("Lütfen 100 karakterden fazla giriş yapmayınız");

        }
    }
}



