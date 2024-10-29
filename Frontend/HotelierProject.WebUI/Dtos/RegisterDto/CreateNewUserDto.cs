using System.ComponentModel.DataAnnotations;

namespace HotelierProject.WebUI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage ="Ad Giriniz.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad Giriniz.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı Giriniz.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mail Giriniz.")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Şifre Giriniz.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifreyi tekrar Giriniz.")]
        [Compare("Password",ErrorMessage = "Şifreler uyuşmuyor.")]
        public string ConfirmPassword { get; set; }

    }
}
