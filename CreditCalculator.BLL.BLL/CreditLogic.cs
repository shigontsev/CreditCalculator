using CreditCalculator.BLL.Interfaces;
using CreditCalculator.DAL.Interfaces;
using CreditCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCalculator.BLL.BLL
{
    public class CreditLogic : ICreditLogic
    {
        ICreditDAO _creditDAO;

        public CreditLogic(ICreditDAO creditDAO) 
        { 
            _creditDAO = creditDAO;
        }
        
        public IEnumerable<PaymentRow> GetPaymentListByMounth(Loan loanMounth)
        {
            return _creditDAO.GetPaymentListByMounth(loanMounth);
        }

        public IEnumerable<PaymentRow> GetPaymentListByYear(Loan loanYear)
        {
            return _creditDAO.GetPaymentListByYear(loanYear);
        }
    }
}
