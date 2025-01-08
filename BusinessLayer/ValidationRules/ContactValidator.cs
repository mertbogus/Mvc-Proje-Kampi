using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {

            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Maili Boş Bırakamazsınız.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Adını Boş Bırakamazsınız.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adınız Boş Bırakamazsınız.");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Lütfen En Az 3 karakter Girişi Yapınız.");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("En Fazla 50  karakter Girişi Yapabilirsiniz.");
        }

    }
}
