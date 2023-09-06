using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class GuideValidator : AbstractValidator<Guide>
    {
        public GuideValidator() //guide constrocter oluşturduğumuzda burası geliyor
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen İsim ve Soyisim giriniz.");//ekleme yaparken hata yaptıysak bize gösteriyor.
            RuleFor(x => x.Description).NotEmpty().WithMessage("Lütfen Bir Kısa Açıklama Giriniz.");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Lütfen Bir Görsel Ekleyiniz.");
            RuleFor(x => x.Name).MaximumLength(15).WithMessage("Lütfen en fazla 15 karakter giriniz");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Lütfen 3 karakter fazla giriniz");
        }
    }
}
