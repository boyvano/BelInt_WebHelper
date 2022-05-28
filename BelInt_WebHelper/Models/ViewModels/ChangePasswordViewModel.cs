using System;
using System.ComponentModel.DataAnnotations;

namespace BelInt_WebHelper.Models.ViewModels
{
    public class ChangePasswordViewModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Старый пароль")]
        public string OldPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Новый пароль")]
        public string NewPassword { get; set; }

        [Required]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают!")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить новый пароль")]
        public string PasswordConfirm { get; set; }
    }
}
