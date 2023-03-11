using CreditCalculator.Entities;

namespace CreditCalculator.BLL.Interfaces
{
    public interface ICreditLogic
    {
        IEnumerable<PaymentRow> GetPaymentListByYear(Loan loanYear);

        IEnumerable<PaymentRow> GetPaymentListByMounth(Loan loanMounth);
    }
}
