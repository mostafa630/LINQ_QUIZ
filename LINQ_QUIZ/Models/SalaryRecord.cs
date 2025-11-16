using LINQ_QUIZ.Enums;

namespace LINQ_QUIZ.Models
{
    internal class SalaryRecord
    {
        public decimal Amount { get; private set; }
        public Month Month { get; private set; }
        public SalaryRecord(decimal amount, Month month)
        {
            Amount = amount;
            Month = month;
        }

    }
}
