using CreditCalculator.BLL.Interfaces;
using CreditCalculator.Dependencies;
using CreditCalculator.Entities;

namespace CreditCalculator.PL.WebApp.ViewModels
{
    public class CreditViewModel
    {
        private ICreditLogic creditBll;

        public CreditViewModel() 
        {
            creditBll = DependencyResolver.Instance.CreditLogic;
        }

        public IEnumerable<PaymentRowViewModel> GetPaymentListByYear(LoanViewModel loanYear)
        {
            foreach (var row in creditBll.GetPaymentListByYear(new Loan(loanYear.Sum, loanYear.Deadline, loanYear.Rate)))
            {
                yield return new PaymentRowViewModel(row.N, row.Date, row.Sum, row.SumByPercent, row.BalanceOwed);
            }
        }

        public IEnumerable<PaymentRowViewModel> GetPaymentListByMounth(LoanViewModel loanMounth)
        {
            foreach (var row in creditBll.GetPaymentListByMounth(new Loan(loanMounth.Sum, loanMounth.Deadline, loanMounth.Rate, loanMounth.Step)))
            {
                yield return new PaymentRowViewModel(row.N, row.Date, row.Sum, row.SumByPercent, row.BalanceOwed);
            }
        }

    }
}
