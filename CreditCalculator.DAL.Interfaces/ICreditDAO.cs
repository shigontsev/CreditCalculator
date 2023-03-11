using CreditCalculator.Entities;

namespace CreditCalculator.DAL.Interfaces
{
    public interface ICreditDAO
    {
        IEnumerable<PaymentRow> GetPaymentListByYear(Loan loanYear);

        IEnumerable<PaymentRow> GetPaymentListByMounth(Loan loanMounth);
    }
}
