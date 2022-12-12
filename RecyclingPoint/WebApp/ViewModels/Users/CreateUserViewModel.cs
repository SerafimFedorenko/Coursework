using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels.Users
{
    public class CreateUserViewModel
    {
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Роль")]
        public string UserRole { get; set; }
        public CreateUserViewModel()
        {
            UserRole = "user";
        }

    }
}
