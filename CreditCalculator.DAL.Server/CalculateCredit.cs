using CreditCalculator.Entities;

namespace CreditCalculator.DAL.Server
{
    internal static class CalculateCredit
    {
        //Проблемы есть с подсчетом чисел с плавающей точкой, поэтом обернул в Round,
        //но думаю следовало мне decimel использовать

        internal static IEnumerable<PaymentRow> PaymentScheduleAnnuitet(double SumCredit, double InterestRateYear, int CreditPeriod) // Метод расчета Аннуитетного платежа
        {
            double InterestRateMonth = InterestRateYear / 12 / 100;

            double Payment = Math.Round(
                SumCredit * (InterestRateMonth / (1 - Math.Pow(1 + InterestRateMonth, -CreditPeriod))),
                2); // Ежемесячный платеж
            
            double ItogCreditSum = Math.Round(Payment * CreditPeriod, 2); // Итоговая сумма кредита

            // Заполняем график платежей
            double SumCreditOperation = SumCredit;
            double ItogCreditSumOperation = ItogCreditSum;

            DateTime date = DateTime.Now;
            for (int i = 0; i < CreditPeriod; ++i)
            {
                double procent = Math.Round(SumCreditOperation * InterestRateMonth, 2);
                SumCreditOperation = Math.Round(SumCreditOperation - Math.Round(Payment - procent,2), 2);

                yield return new PaymentRow(
                    i + 1,
                    date,
                    Payment,
                    procent,
                    SumCreditOperation);
                date = date.AddMonths(1);

                ItogCreditSumOperation = Math.Round(ItogCreditSumOperation - Payment, 2);
            }
        }

        internal static IEnumerable<PaymentRow> PaymentScheduleOnMounth(double SumCredit, double InterestRateYear, int CreditPeriod, int Step) // Метод расчета Аннуитетного платежа
        {
            double InterestRateMonth = InterestRateYear / 30 /100;

            int newCreditPeriod = CreditPeriod / Step;
            if(CreditPeriod % Step>0)
                newCreditPeriod++;

            double Payment = Math.Round(SumCredit * (InterestRateMonth / (1 - Math.Pow(1 + InterestRateMonth, -newCreditPeriod))), 2); // Ежемесячный платеж
            double ItogCreditSum = Math.Round(Payment * newCreditPeriod, 2); // Итоговая сумма кредита

            // Заполняем график платежей
            double SumCreditOperation = SumCredit;
            double ItogCreditSumOperation = ItogCreditSum;

            DateTime date = DateTime.Now;
            for (int i = 0; i < newCreditPeriod; ++i)
            {
                double procent = Math.Round(SumCreditOperation * InterestRateMonth, 2);
                SumCreditOperation = Math.Round(SumCreditOperation - Math.Round(Payment - procent, 2), 2);

                yield return new PaymentRow(
                    i + 1,
                    date,
                    Payment,
                    procent,
                    SumCreditOperation);
                date = date.AddDays(Step);

                ItogCreditSumOperation = Math.Round(ItogCreditSumOperation - Payment, 2);
            }
        }
    }
}