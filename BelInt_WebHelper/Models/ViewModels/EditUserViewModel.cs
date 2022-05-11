using System.ComponentModel.DataAnnotations;
using System;

namespace BelInt_WebHelper.Models.ViewModels
{
    public class EditUserViewModel
    {
        [Key]
        public string Id { get; set; }
        [Required]
        [Display(Name = "Фамилия")]
        public string SurName { get; set; }

        [Required]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Отчество")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата рождения")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Логин")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Отделение")]
        public int DepartmentId { get; set; }

        [Display(Name = "Должность")]
        public string Position { get; set; }

    }
}
