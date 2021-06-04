using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidatior:AbstractValidator<Category>
    {
        public CategoryValidatior()
        {
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklamayı boş geçemezsiniz");
            RuleFor(X => X.CategoryName).NotEmpty().WithMessage("İsim kısmını boş geçemezsiniz");
            RuleFor(X => X.CategoryName).MinimumLength(3).WithMessage("En az 3 Karakter girilmeli");
            RuleFor(X => X.CategoryName).MaximumLength(20).WithMessage("Lütfen 20 karakterden fazla giriş yapmayınız");
        }
    }
}
