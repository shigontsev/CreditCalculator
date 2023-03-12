using CreditCalculator.DAL.Interfaces;
using CreditCalculator.Entities;
using Microsoft.VisualBasic;

namespace CreditCalculator.DAL.Server
{
    public class CreditDAO : ICreditDAO
    {
        public IEnumerable<PaymentRow> GetPaymentListByMounth(Loan loanMounth)
        {
            return CalculateCredit.PaymentScheduleOnMounth(loanMounth.Sum, loanMounth.Rate, loanMounth.Deadline, loanMounth.Step);
        }

        public IEnumerable<PaymentRow> GetPaymentListByYear(Loan loanYear)
        {
            return CalculateCredit.PaymentScheduleAnnuitet(loanYear.Sum, loanYear.Rate, loanYear.Deadline);
        }
    }
}