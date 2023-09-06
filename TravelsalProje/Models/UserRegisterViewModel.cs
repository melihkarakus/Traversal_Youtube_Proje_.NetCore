using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TravelsalProje.Models
{
    public class UserRegisterViewModel //model içinde oluşturduğumuz sınıfta bize kullanıcı oluşturduğumuzda eksik yerleri doldurduğumuzda uyarılar verilmesi içindir.
    {
        [Required(ErrorMessage ="Lütfen Adınızı Giriniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Soyadınızı Giriniz")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Lütfen Kullanıcı Adınızı Giriniz")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lütfen Mail Giriniz")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen Şifreyi Tekrar Giriniz")]  //Hata mesajı verdirir.
        [Compare("Password",ErrorMessage ="Şifreler Uyumlu Değil!")] // Şifrelerin uyumlu olup olmadığına bakar
        public string ConfirmPassword { get; set; }
    }
}
