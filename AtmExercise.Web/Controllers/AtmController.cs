using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtmExercise.Model;
using AtmExercise.Model.Exception;
using AtmExercise.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtmExercise.Web.Controllers
{
    public class AtmController : Controller
    {

        private readonly IService<CreditCard> _ccService;
        private readonly OperationService _operationService;

        public AtmController(IService<CreditCard> ccService, OperationService operationService)
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

        public IActionResult Balance(int creditCardId)
        {
            ViewBag.CreditCardId = creditCardId;
            this._operationService.InsertBalance(creditCardId);
            var creditCard = this._ccService.GetById(creditCardId);
            return PartialView("_Balance", creditCard);
        }

        public IActionResult WithDrawal(int creditCardId)
        {
            ViewBag.CreditCardId = creditCardId;
            return PartialView("_WithDrawal");
        }

        [HttpPost]
        public IActionResult WithDrawal(int creditCardId, int amount)
        {
            ViewBag.CreditCardId = creditCardId;
            try
            {
                this._operationService.InsertWithDrawal(creditCardId, amount);
                return PartialView("_WithDrawal");
            }
            catch (AtmNotCreditException ex)
            {
                return RedirectToActionPermanent("Error", "Login", new { reason = ex.Message });
            }
        }
    }
}