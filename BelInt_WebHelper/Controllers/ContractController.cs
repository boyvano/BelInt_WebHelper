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
        GanerateContracts getlistexcel = new Models.DataModels.GanerateContracts();
        [HttpGet]
        public IActionResult Index()
        {
            getlistexcel = new Models.DataModels.GanerateContracts();
            return View(model: getlistexcel.GetExcelItems());
        }

        [HttpGet]
        public  FileResult GetSomeFile(List<Contract> contracts)
        {
                var result = new PhysicalFileResult(getlistexcel.GenDocxContract(contracts.FirstOrDefault()), "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
                return result;
            

        }
    }
}
