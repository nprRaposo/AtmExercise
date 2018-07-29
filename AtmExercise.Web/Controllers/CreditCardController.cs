using AtmExercise.Model;
using AtmExercise.Model.Exception;
using AtmExercise.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtmExercise.Web.Controllers
{
    public class CreditCardController : Controller
    {

        private readonly IService<CreditCard> _ccService;

        public CreditCardController(IService<CreditCard> ccService)
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
                return View();
            }
            catch (AtmException ex)
            {
                return RedirectToActionPermanent("EnteringPing", new { creditCardNumber, pinFailed = true });
            }
            catch (AtmExceptionCardBlocked ex)
            {
                return RedirectToActionPermanent("Error", new { reason = ex.Message });
            }
        }

        public ActionResult Error(string reason)
        {
            ViewBag.Reason = reason;
            return View();
        }

        // GET: CreditCard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CreditCard/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}