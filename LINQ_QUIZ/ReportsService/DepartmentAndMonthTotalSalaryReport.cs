using LINQ_QUIZ.Enums;

namespace LINQ_QUIZ.ReportsService
{
    internal class DepartmentAndMonthTotalSalaryReport
    {
        public IEnumerable<DepartmentAndMonthTotalSalary> GenerateDepartmentAndMonthTotalSalaryReport()
        {
            var users = DataBase.UserSource.GetAllUsers();

            var UsersSalariesAndDepartments = users.
            SelectMany(u => u.SalaryRecord.Select(r => new
            {
                Department = u.Department,
                Month = r.Month,
                Salary = r.Amount
            }));

            var groups = UsersSalariesAndDepartments
            .GroupBy(g => new
            {
                g.Department,
                g.Month
            });

            var report = groups
            .Select(g => new DepartmentAndMonthTotalSalary
            {
                DepartmentName = g.Key.Department.Name,
                Month = g.Key.Month,
                TotalSalary = g.Sum(r => r.Salary)
            });

            return report;
        }
    }

    public class DepartmentAndMonthTotalSalary
    {
        public string DepartmentName { get; set; }
        public Month Month { get; set; }
        public decimal TotalSalary { get; set; }

        public override string ToString()
        {
            return $"{DepartmentName} - {Month.ToString()} - {TotalSalary}";
        }
    }
}
