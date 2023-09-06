using System.ComponentModel.DataAnnotations;

namespace TravelsalProje.Models
{
    public class UserSıgnInViewModel 
    {
        [Required(ErrorMessage ="Lütfen kullanıcı adınızı giriniz.")]
        public string username { get; set; }

        [Required(ErrorMessage ="Lütfen şifrenizi girinizi.")]
        public string password { get; set; } // model içinde tanımlama yapılacaksa password veya int olan herhangi propertileri string olarak tutulmalı yoksa çakışıyor.
    }
}
