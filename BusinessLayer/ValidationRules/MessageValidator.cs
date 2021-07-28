using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator: AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Lütfen Alıcı Mail Adresini Giriniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Lütfen Konu Giriniz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Lütfen Mesaj Giriniz");
            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Lütfen Uygun Mail Adresi Giriniz");
            RuleFor(X => X.Subject).MinimumLength(15).WithMessage("En az 16 Karakter girilmeli veya boşuk karakteri bırakabilirsiniz");
            RuleFor(X => X.Subject).MaximumLength(100).WithMessage("En fazla 100 Karakter girilmeli");

        }

    }
}
