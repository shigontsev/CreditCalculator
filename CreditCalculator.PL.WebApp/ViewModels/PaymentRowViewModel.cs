namespace CreditCalculator.PL.WebApp.ViewModels
{
    public class PaymentRowViewModel
    {

        /// <summary>
        /// Номер платежа
        /// </summary>
        public double N { get; set; }

        /// <summary>
        /// Дата платежа
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Размер платежа по телу
        /// </summary>
        public double Sum { get; set; }

        /// <summary>
        /// Размер платежа по %
        /// </summary>
        public double SumByPercent { get; set; }

        /// <summary>
        /// Остаток основного долга
        /// </summary>
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
