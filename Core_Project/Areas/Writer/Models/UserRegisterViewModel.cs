using System.ComponentModel.DataAnnotations;

namespace Core_Project.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen Adınızı Girin")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lütfen Soyadınızı Girin")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Lütfen Kullanıcı Adını Girin")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Şifreyi Girin")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen Şifreyi Tekrar Girin")]
        [Compare("Password",ErrorMessage ="Şifreler Uyumlu Değil")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Lütfen Mail Girin")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Lütfen Görsel Yolu Girin")]
        public string ImageUrl { get; set; }


    }
}
