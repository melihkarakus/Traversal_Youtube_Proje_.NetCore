using DTOLayer.DTOs.AppUserDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDTO>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad Alanı boş geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad Alanı boş geçilemez");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Alanı boş geçilemez");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı Adı Alanı boş geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre Alanı boş geçilemez");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Doğrulanacak Şifre Alanı boş geçilemez");
            RuleFor(x => x.Username).MinimumLength(5).WithMessage("Kullanıcı Adı minimum 5 karakter veri girişi yapınız");
            RuleFor(x => x.Username).MaximumLength(20).WithMessage("Kullanıcı Adı minimum 20 karakter veri girişi yapınız");
            RuleFor(x => x.Password).Equal(y => y.ConfirmPassword).WithMessage("Şifreler uyuşmamaktadır");
        }
    }
}
