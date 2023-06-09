﻿using CreditCalculator.BLL.Interfaces;
using CreditCalculator.DAL.Interfaces;
using CreditCalculator.Entities;

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
