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

    internal static class CalculateCredit
    {
        internal static IEnumerable<PaymentRow> PaymentScheduleAnnuitet(double SumCredit, double InterestRateYear, int CreditPeriod) // Метод расчета Аннуитетного платежа
        {
            double InterestRateMonth = InterestRateYear / 12 / 100;

            double Payment = Math.Round(
                SumCredit * (InterestRateMonth / (1 - Math.Pow(1 + InterestRateMonth, -CreditPeriod))),
                2); // Ежемесячный платеж

            //double Payment = SumCredit * (InterestRateMonth * Math.Pow(1 + InterestRateMonth, CreditPeriod) / (-1 + Math.Pow(1 + InterestRateMonth, CreditPeriod))); // Ежемесячный платеж

            double ItogCreditSum = Math.Round(Payment * CreditPeriod, 2); // Итоговая сумма кредита

            //itogPayment.Text = Payment.ToString("N2"); // Выводим в результаты ежемесячный платёж
            //itogSum.Text = (ItogCreditSum).ToString("N2"); // Выводим в результаты итоговую сумму кредита

            // Заполняем график платежей
            double SumCreditOperation = SumCredit;
            double ItogCreditSumOperation = ItogCreditSum;
            //double ItogPlus = 0;
            DateTime date = DateTime.Now;
            for (int i = 0; i < CreditPeriod; ++i)
            {
                double procent = Math.Round(SumCreditOperation * (InterestRateYear / 100) / 12, 2);
                SumCreditOperation -= Payment - procent;

                yield return new PaymentRow(
                    i + 1,
                    date,
                    Payment,
                    procent,
                    SumCreditOperation);
                date = date.AddMonths(1);

                //dgvGrafik.Rows.Add();
                //dgvGrafik[0, i].Value = i + 1; //номер месяца
                //dgvGrafik[1, i].Value = Payment.ToString("N2"); //Ежемесячный платеж
                //dgvGrafik[2, i].Value = (Payment - procent).ToString("N2"); //Платеж за основной долг
                //dgvGrafik[3, i].Value = procent.ToString("N2"); //Платеж процента
                //dgvGrafik[4, i].Value = SumCreditOperation.ToString("N2"); //Основной остаток
                ItogCreditSumOperation -= Payment;
                //ItogPlus = Convert.ToDouble(dgvGrafik[4, i].Value);
            }
            //itogOverpayment.Text = (ItogCreditSum - SumCredit + ItogPlus).ToString("N2");
        }

        internal static IEnumerable<PaymentRow> PaymentScheduleOnMounth(double SumCredit, double InterestRateYear, int CreditPeriod, int Step) // Метод расчета Аннуитетного платежа
        {
            double InterestRateMonth = InterestRateYear / 30 /100;

            int newCreditPeriod = CreditPeriod / Step;
            if(CreditPeriod % Step>0)
                newCreditPeriod++;

            double Payment = Math.Round(SumCredit * (InterestRateMonth / (1 - Math.Pow(1 + InterestRateMonth, -newCreditPeriod))), 2); // Ежемесячный платеж
            double ItogCreditSum = Math.Round(Payment * newCreditPeriod, 2); // Итоговая сумма кредита

            //itogPayment.Text = Payment.ToString("N2"); // Выводим в результаты ежемесячный платёж
            //itogSum.Text = (ItogCreditSum).ToString("N2"); // Выводим в результаты итоговую сумму кредита

            // Заполняем график платежей
            double SumCreditOperation = SumCredit;
            double ItogCreditSumOperation = ItogCreditSum;
            //double ItogPlus = 0;
            DateTime date = DateTime.Now;
            for (int i = 0; i < newCreditPeriod; ++i)
            {
                double procent = Math.Round(SumCreditOperation * (InterestRateYear / 100) / 30, 2);
                SumCreditOperation -= Payment - procent;

                yield return new PaymentRow(
                    i + 1,
                    date,
                    Payment,
                    procent,
                    SumCreditOperation);
                date = date.AddDays(Step);

                //dgvGrafik.Rows.Add();
                //dgvGrafik[0, i].Value = i + 1; //номер месяца
                //dgvGrafik[1, i].Value = Payment.ToString("N2"); //Ежемесячный платеж
                //dgvGrafik[2, i].Value = (Payment - procent).ToString("N2"); //Платеж за основной долг
                //dgvGrafik[3, i].Value = procent.ToString("N2"); //Платеж процента
                //dgvGrafik[4, i].Value = SumCreditOperation.ToString("N2"); //Основной остаток
                ItogCreditSumOperation -= Payment;
                //ItogPlus = Convert.ToDouble(dgvGrafik[4, i].Value);
            }
            //itogOverpayment.Text = (ItogCreditSum - SumCredit + ItogPlus).ToString("N2");
        }
    }
}