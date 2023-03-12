using System.ComponentModel.DataAnnotations;

namespace CreditCalculator.PL.WebApp.ViewModels
{
    public class PaymentRowViewModel
    {

        /// <summary>
        /// Номер платежа
        /// </summary>
        [Display(Name = "Номер платежа")]
        public double N { get; set; }

        /// <summary>
        /// Дата платежа
        /// </summary>
        [Display(Name = "Дата платежа")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        /// <summary>
        /// Размер платежа по телу
        /// </summary>
        [Display(Name = "Размер платежа по телу")]
        public double Sum { get; set; }

        /// <summary>
        /// Размер платежа по %
        /// </summary>
        [Display(Name = "Размер платежа по %")] 
        public double SumByPercent { get; set; }

        /// <summary>
        /// Остаток основного долга
        /// </summary>
        [Display(Name = "Остаток основного долга")]
        public double BalanceOwed { get; set; }

        public PaymentRowViewModel(double n, DateTime date, double sum, double sumByPercent, double balanceOwed)
        {
            N = n;
            Date = date;
            Sum = sum;
            SumByPercent = sumByPercent;
            BalanceOwed = balanceOwed;
        }
    }
}
