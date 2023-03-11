//using CreditCalculator.Entities;
using CreditCalculator.PL.WebApp.Models;
using CreditCalculator.PL.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
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

        //[HttpGet]
        public IActionResult LoanRequestForYear()
        {
            return View();
        }

        [HttpPost]
        //public IEnumerable<PaymentRowViewModel> Credit(string a)
        public IActionResult LoanRequestForYear(LoanViewModel loan)
        {
            return RedirectToAction("СreditPlan", "Home", 
                new 
                { 
                    sum = loan.Sum, 
                    deadline = loan.Deadline, 
                    rate = loan.Rate, 
                    forYear = true
                });

        }

        public IActionResult LoanRequestForMounth()
        {
            return View();
        }

        [HttpPost]
        //public IEnumerable<PaymentRowViewModel> Credit(string a)
        public IActionResult LoanRequestForMounth(LoanViewModel loan)
        {
            return RedirectToAction("СreditPlan", "Home",
                new
                {
                    sum = loan.Sum,
                    deadline = loan.Deadline,
                    rate = loan.Rate,
                    step = loan.Step,
                    forYear = false
                });

        }

        //[HttpGet]
        public IActionResult СreditPlan(double sum, int deadline, double rate, int step, bool forYear)
        {
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
            
            
            return View(list);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}