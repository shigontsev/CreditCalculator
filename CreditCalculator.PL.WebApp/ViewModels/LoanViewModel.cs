using System.ComponentModel.DataAnnotations;

namespace CreditCalculator.PL.WebApp.ViewModels
{
    public record class LoanViewModel : IValidatableObject
    {
        [Display(Name = "Сумма займа")]
        [MinValue]
        [Required(ErrorMessage = "Не указана Сумма займа")]
        public double Sum { get;  set; }

        [Display(Name = "Срок займа")]
        [MinValue]
        [Required(ErrorMessage = "Не указан Срок займа")]
        public int Deadline { get; set; }

        [Display(Name = "Ставка")]
        [MinValue]
        [Required(ErrorMessage = "Не указана Ставка")]
        public double Rate { get; set; }

        [Display(Name = "Шаг платежа")]
        [MinValue]
        [Required(ErrorMessage = "Не указан Шаг платежа")]
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (Sum <= 0) 
            {
                errors.Add(new ValidationResult(
                    nameof(Sum) + " должна быть положительной > 0"));
            }
            if (Deadline <= 0)
            {
                errors.Add(new ValidationResult(
                    nameof(Deadline) + " должен быть положительным > 0"));
            }
            if (Rate <= 0)
            {
                errors.Add(new ValidationResult(
                    nameof(Rate) + " должна быть положительной > 0"));
            }
            if (Step <= 0)
            {
                errors.Add(new ValidationResult(
                    nameof(Step) + " должен быть положительным > 0"));
            }
            if (Step > Deadline)
            {
                errors.Add(new ValidationResult(
                    nameof(Step) + " должен быть  <= Срока займа"));
            }

            return errors;
        }
    }
    public class MinValueAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is int valueInt)
            {
                if (valueInt > 0)
                    return true;
                else
                    ErrorMessage = "Значение  должно быть > 0";
            }
            if (value is double valueDouble)
            {
                if (valueDouble > 0)
                    return true;
                else
                    ErrorMessage = "Значение должно быть > 0";
            }
            return false;
        }
    }
}
