using LINQ_QUIZ.Enums;
using LINQ_QUIZ.Exceptions;
using LINQ_QUIZ.Settings;

namespace LINQ_QUIZ.Models
{
    internal class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Country { get; private set; }
        public Department? Department { get; private set; }
        public User? Manager { get; private set; }
        public List<SalaryRecord> SalaryRecord { get; private set; }
        private int appraisalCount = 0;

        public User(int id, string name, int age, string country, User? manager, Department? department, decimal initialSalary)
        {
            Id = id;
            Name = name;
            Age = age;
            Country = country;
            Department = department;
            Manager = manager;
            var currentMonth = (Month)DateTime.Now.Month;

            ValidateSalary(initialSalary);
            SalaryRecord = new List<SalaryRecord>
            {
                new SalaryRecord(initialSalary,currentMonth)
            };
        }
        public void MakeAppraisal(decimal percentage)
        {
            if (SalaryRecord == null || !CanAppraise())
                return;

            var newSalaryAmount = GetSalaryAfterAppraisal(percentage);
            ValidateSalary(newSalaryAmount);

            AddSalaryRecord(newSalaryAmount, (Month)DateTime.Now.Month);
            appraisalCount++;
        }
        private decimal GetSalaryAfterAppraisal(decimal percentage)
        {
            var lastSalry = GetCurrentSalary();
            var salaryAfterAppraisal = lastSalry != null ? lastSalry + (lastSalry * percentage / 100) : 0;
            return salaryAfterAppraisal;
        }
        private void AddSalaryRecord(decimal salary, Month month)
        {
            SalaryRecord.Add(new SalaryRecord(salary, month));
        }
        private bool CanAppraise()
        {
            if ((Month)DateTime.Now.Month == Month.January)
            {
                appraisalCount = 0;
            }
            return appraisalCount < UserSettings.MaxAppraisalCount;
        }

        public decimal GetCurrentSalary()
        {
            return SalaryRecord.Count() == 0 ? 0 : SalaryRecord.Last().Amount;
        }

        private void ValidateSalary(decimal salary)
        {
            checkMinSalary(salary);
            checkManagerSalary(salary);
        }
        private void checkMinSalary(decimal salary)
        {
            if (salary < UserSettings.MinSalary)
            {
                throw new InvalidSalaryException($"slary must be at least = {UserSettings.MinSalary} and this salary {salary}");
            }
        }
        private void checkManagerSalary(decimal salary)
        {
            if (Manager != null)
            {
                var managerSalary = Manager.GetCurrentSalary();
                if (salary > managerSalary)
                {
                    throw new InvalidSalaryException($"Invalid becuse this Salary = {salary} and that more than manager salary = {managerSalary}");
                }
            }
        }
        public bool IsHeadOfDepartment()
        {
            return this.Manager == null;
        }
        public override string ToString()
        {
            return $"UserId = {Id} , UserName = {Name}";
        }
    }
}
