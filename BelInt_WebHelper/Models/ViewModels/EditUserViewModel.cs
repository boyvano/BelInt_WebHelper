using System.ComponentModel.DataAnnotations;
using System;

namespace BelInt_WebHelper.Models.ViewModels
{
    public class EditUserViewModel: CreateUserViewModel
    {        
        public string Id { get; set; }
    }
}
