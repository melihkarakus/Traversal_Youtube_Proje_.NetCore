using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AnnouncementValidator : AbstractValidator<AnnouncementAddDTO> //bizim dto katmanımızdaki anonucement içindeki verileri bazılarını kural koymak için yarıyor
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Lütfen Başlığı Boş Geçmeyin.");//Dto katmanından anouncement de olan tanımlanan classlar
            RuleFor(x => x.Content).NotEmpty().WithMessage("Lütfen İçeriği Boş Geçmeyin.");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Lütfen Başlığı En Az 5 Veri Giriniz");
            RuleFor(x=>x.Title).MaximumLength(50).WithMessage("Lütfen Başlığı En Fazla 50 Veri Giriniz");
            RuleFor(x => x.Content).MinimumLength(5).WithMessage("Lütfen İçeriği En Az 5 Veri Giriniz");
            RuleFor(x => x.Content).MaximumLength(500).WithMessage("Lütfen İçeriği En Fazla 500 Veri Giriniz");
        }
    }
}
