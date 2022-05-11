using System.ComponentModel.DataAnnotations;
using System;

namespace BelInt_WebHelper.Models.ViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }
    }
}
