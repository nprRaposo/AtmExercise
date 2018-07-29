using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtmExercise.Model;
using AtmExercise.Service;
using Microsoft.AspNetCore.Mvc;

namespace AtmExercise.Web.Controllers
{
    public class AtmController : Controller
    {

        private readonly IService<CreditCard> _ccService;
        private readonly IService<Operation> _operationService;

        public AtmController(IService<CreditCard> ccService)
        {
            this._ccService = ccService;
        }

        public IActionResult Home(int creditCardId)
        {
            return View();
        }

        public IActionResult Balance()
        {
            return PartialView("_Balance");
        }

        public IActionResult WithDrawal()
        {
            return PartialView("_WithDrawal");
        }
    }
}