using CreditCalculator.PL.WebApp.Models;
using CreditCalculator.PL.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Diagnostics;

namespace CreditCalculator.PL.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private CreditViewModel _credit;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _credit = new CreditViewModel();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult LoanRequestForYear()
        {
            return View();
        }

        [HttpPost]        
        public IActionResult LoanRequestForYear(LoanViewModel loan)
        {            
            if (ModelState.IsValid)
                return RedirectToAction("СreditPlan", "Home",
                new
                {
                    sum = loan.Sum,
                    deadline = loan.Deadline,
                    rate = loan.Rate,
                    forYear = true
                });

            if (loan.Sum <= 0)
                ModelState.AddModelError(nameof(loan.Sum), nameof(loan.Sum) + " - не может быть <= 0.");
            if (loan.Deadline <= 0)
                ModelState.AddModelError(nameof(loan.Deadline), nameof(loan.Deadline) + " - не может быть <= 0.");
            if (loan.Rate <= 0)
                ModelState.AddModelError(nameof(loan.Rate), nameof(loan.Rate) + " - не может быть <= 0.");
            
            return View(loan);

        }

        public IActionResult LoanRequestForMounth()
        {
            return View();
        }

        [HttpPost]        
        public IActionResult LoanRequestForMounth(LoanViewModel loan)
        {
            if (ModelState.IsValid)
                return RedirectToAction("СreditPlan", "Home",
                new
                {
                    sum = loan.Sum,
                    deadline = loan.Deadline,
                    rate = loan.Rate,
                    step = loan.Step,
                    forYear = false
                });
            if (loan.Sum <= 0)
                ModelState.AddModelError(nameof(loan.Sum), nameof(loan.Sum) + " - не может быть <= 0.");
            if (loan.Deadline <= 0)
                ModelState.AddModelError(nameof(loan.Deadline), nameof(loan.Deadline) + " - не может быть <= 0.");
            if (loan.Rate <= 0)
                ModelState.AddModelError(nameof(loan.Rate), nameof(loan.Rate) + " - не может быть <= 0.");
            if (loan.Step <= 0)
                ModelState.AddModelError(nameof(loan.Step), nameof(loan.Step) + " - не может быть <= 0.");
            if (loan.Step > loan.Deadline)
                ModelState.AddModelError(nameof(loan.Step), nameof(loan.Step) + " - не может быть > Срока займа.");

            return View(loan);
        }

        public IActionResult СreditPlan(double sum, int deadline, double rate, int step, bool forYear)
        {
            ViewBag.Sum = sum;
            
            IEnumerable<PaymentRowViewModel> list;
            if (forYear) {
                list = _credit.GetPaymentListByYear(
                new LoanViewModel(sum, deadline, rate));
            }
            else
            {
                list = _credit.GetPaymentListByMounth(
                new LoanViewModel(sum, deadline, rate, step));
            }
            ViewBag.TypeInfoCalculate = forYear? "за годичный расчет": "за месячный расчет";
            ViewBag.SumLoan = Math.Round(list.First().Sum * list.Count(), 2);

            return View(list);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}