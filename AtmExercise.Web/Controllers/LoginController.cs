﻿using AtmExercise.Model;
using AtmExercise.Model.Exception;
using AtmExercise.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtmExercise.Web.Controllers
{
    public class LoginController : Controller
    {

        private readonly IService<CreditCard> _ccService;

        public LoginController(IService<CreditCard> ccService)
        {
            this._ccService = ccService;
        }

        // GET: CreditCard
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string creditCardNumber)
        {
            try
            {
                var creditCardNumberSanitized = creditCardNumber.Replace("-", string.Empty);
                var creditCard = this._ccService.Exists(creditCardNumberSanitized);
                return RedirectToActionPermanent("EnteringPing", new { creditCardNumber });
            }
            catch (AtmException ex)
            {
                return RedirectToActionPermanent("Error", new { reason = ex.Message });                
            }
        }

        public ActionResult EnteringPing(string creditCardNumber, bool pinFailed)
        {
            ViewBag.CreditCardNumber = creditCardNumber;
            ViewBag.PinFailed = pinFailed;
            return View();
        }

        [HttpPost]
        public ActionResult EnteringPingPost(string creditCardNumber, string creditCardPin)
        {
            try
            {
                var creditCardNumberSanitized = creditCardNumber.Replace("-", string.Empty);
                var creditCard = this._ccService.GetBy(new string[] { creditCardNumberSanitized, creditCardPin });
                return RedirectToActionPermanent("Home", "Atm", new { creditCardId = creditCard.Id });
            }
            catch (AtmException)
            {
                return RedirectToActionPermanent("EnteringPing", new { creditCardNumber, pinFailed = true });
            }
            catch (AtmCardBlockedException ex)
            {
                return RedirectToActionPermanent("Error", new { reason = ex.Message });
            }
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Error(string reason)
        {
            ViewBag.Reason = reason;
            return View();
        }
    }
}