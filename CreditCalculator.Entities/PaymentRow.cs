namespace CreditCalculator.Entities
{
    public class PaymentRow
    {
        /// <summary>
        /// Номер платежа
        /// </summary>
        private double n;

        public double N
        {
            get { return n; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(nameof(N), nameof(N) + "должен быть > 0");
                n = value;
            }
        }
        /// <summary>
        /// Дата платежа
        /// </summary>
        public DateTime Date { get; private set; }

        /// <summary>
        /// Размер платежа по телу
        /// </summary>
        private double sum;

        public double Sum
        {
            get { return sum; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(nameof(Sum), nameof(Sum) + "должен быть > 0");
                sum = value;
            }
        }

        /// <summary>
        /// Размер платежа по %
        /// </summary>
        private double sumByPercent;        

        public double SumByPercent
        {
            get { return sumByPercent; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(nameof(SumByPercent), nameof(SumByPercent) + "должен быть > 0");
                sumByPercent = value;
            }
        }

        /// <summary>
        /// Остаток основного долга
        /// </summary>
        private double balanceOwed;

        public double BalanceOwed
        {
            get { return balanceOwed; }
            private set
            {
                //if (value < 0)
                //    throw new ArgumentException(nameof(BalanceOwed), nameof(BalanceOwed) + "должен быть >= 0");
                balanceOwed = value;
            }
        }

        public PaymentRow(double n, DateTime date, double sum, double sumByPercent, double balanceOwed)
        {
            N = n;
            Date = date;
            Sum = sum;
            SumByPercent = sumByPercent;
            BalanceOwed = balanceOwed;
        }
    }
}
