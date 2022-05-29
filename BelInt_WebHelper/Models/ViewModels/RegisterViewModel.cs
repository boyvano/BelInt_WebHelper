using System;
using System.ComponentModel.DataAnnotations;

namespace BelInt_WebHelper.Models.ViewModels
{
    public class RegisterViewModel
    {
        private const string minDate = "01/01/1950";// DateTime.Now.AddYears(-80).ToShortDateString();
        private const string maxDate = "01/01/2004";//DateTime.Now.AddYears(-18).ToShortDateString();

        [Required(ErrorMessage = "Введите Фамилию")]
        [Display(Name = "Фамилия")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Введите Имя")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Введите Отчество")]
        [Display(Name = "Отчество")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Введите Дату рождения пользователя")]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), minDate, maxDate, ErrorMessage = "Значение для поля {0} должно быть между {1} и {2}")]
        [Display(Name = "Дата рождения")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Введите Логин пользователя")]
        [Display(Name = "Логин")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Введите электронный адрес почты")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Отделение")]
        public int DepartmentId { get; set; }

        [Display(Name = "Должность")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Введите Пароль пользователя")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Пароль должен иметь минимум {2} символа!", MinimumLength = 3)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Введите Пароль пользователя")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают!")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }

    }
}
