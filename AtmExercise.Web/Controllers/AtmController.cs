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

        public AtmController(IService<CreditCard> ccService, IService<Operation> operationService)
        {
            this._ccService = ccService;
            this._operationService = operationService;
        }

        public IActionResult Home(int creditCardId)
        {
            ViewBag.CreditCardId = creditCardId;
            var operations = this._operationService.GetAllBy(creditCardId.ToString());
            return View(operations);
        }

        public IActionResult Balance(int id)
        {
            var creditCard = this._ccService.GetById(id);
            return PartialView("_Balance", creditCard);
        }

        public IActionResult WithDrawal()
        {
            return PartialView("_WithDrawal");
        }
    }
}