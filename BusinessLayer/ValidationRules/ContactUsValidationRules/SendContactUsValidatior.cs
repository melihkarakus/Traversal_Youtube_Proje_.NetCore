using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.ContactUsValidationRules
{
    public class SendContactUsValidatior : AbstractValidator<SendMessageDTO>
    {
        public SendContactUsValidatior()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Alanı Boş Geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Alanı Boş Geçilemez");
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Alanı Boş Geçilemez");
            RuleFor(x => x.MessageBody).NotEmpty().WithMessage("Mesaj Alanı Boş Geçilemez");
            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Konu Alanına En az 5 karakter veri girişi yapmalısınız");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Konu Alanına En az 100 karakter veri girişi yapmalısınız");
        }
    }
}
