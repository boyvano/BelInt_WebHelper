using BelInt_WebHelper.Models.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BelInt_WebHelper.Models.ViewModels
{
    public class CheckContractModel : Contract
    {
        [Display()]
        public bool IsChecked { get; set; }
    }
}
