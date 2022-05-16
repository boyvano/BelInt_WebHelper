using BelInt_WebHelper.Models.DataModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelInt_WebHelper.Controllers
{
    [Authorize]
    public class ContractController : Controller
    {
        public IActionResult Index()
        {
            var getlistexcel = new Models.DataModels.GanerateContracts();
            return View(model: getlistexcel.GetExcelItems());
        }
    }
}
