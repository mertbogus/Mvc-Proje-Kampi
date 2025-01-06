using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adını Boş Geçemezsiniz.");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar SoyAdını Boş Geçemezsiniz.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Yazar Hakkında Kısmını Boş Geçemezsiniz.");
            RuleFor(x => x.WriterSurname).MinimumLength(3).WithMessage("Lütfen En Az 3 Karakter Girişi Yapınız.");
            RuleFor(x => x.WriterSurname).MaximumLength(20).WithMessage("Lütfen  20 Karakterden Fazla Karakter Girişi Yapmayın.");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Lütfen Geçerli Bir Mail Adresi Giriniz.");
            RuleFor(x => x.WriterTitle).MaximumLength(20).WithMessage("Lütfen  20 Karakterden Fazla Karakter Girişi Yapmayın.");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Unvan Kısmını Boş Geçemezsiniz.");
        }
    }
}
