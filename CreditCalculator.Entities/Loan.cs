using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCalculator.Entities
{
    public class Loan
    {
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

        private int deadline;

        public int Deadline
        {
            get { return deadline; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(nameof(Deadline), nameof(Deadline) + "должен быть > 0");
                deadline = value;
            }
        }

        private double rate;

        public double Rate
        {
            get { return rate; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException(nameof(Rate), nameof(Rate) + "должен быть > 0");
                rate = value;
            }
        }

        private int step;

        public int Step
        {
            get { return step; }
            private set
            {
                if (value <= 0 && value > Deadline)
                    throw new ArgumentException(nameof(Step), nameof(Step) + "должен быть > 0 и <= "+ nameof(Deadline));
                step = value;
            }
        }
        public Loan(double sum, int deadline, double rate, int step)
        {
            Sum = sum;
            Deadline = deadline;
            Rate = rate;
            Step = step;
        }

        public Loan(double sum, int deadline, double rate)
        {
            Sum = sum;
            Deadline = deadline;
            Rate = rate;
        }
    }
}
