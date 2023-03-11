namespace CreditCalculator.PL.WebApp.ViewModels
{
    public record class LoanViewModel
    {
        public double Sum { get;  set; }

        public int Deadline { get; set; }

        public double Rate { get; set; }

        public int Step { get; set; } = 1;

        public LoanViewModel()
        {
        }
        public LoanViewModel(double sum, int deadline, double rate)
        {
            Sum = sum;
            Deadline = deadline;
            Rate = rate;
        }

        public LoanViewModel(double sum, int deadline, double rate, int step)
        {
            Sum = sum;
            Deadline = deadline;
            Rate = rate;
            Step = step;
        }
    }
}
