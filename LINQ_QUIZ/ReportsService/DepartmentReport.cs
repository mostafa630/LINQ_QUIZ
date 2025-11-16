namespace LINQ_QUIZ.ReportsService
{
    internal class DepartmentReport
    {
        public IEnumerable<DepartmentReportResult> GenerateReport()
        {
            var users = DataBase.UserSource.GetAllUsers();

            var report = users
            .GroupBy(u => new { u.Department.Id, u.Department.Name })
            .Select(g => new DepartmentReportResult
            {
                DepartmentId = g.Key.Id,
                DepartmentName = g.Key.Name,
                EmployeeCount = g.Count(),
                HeadOfDepartmentName = g.FirstOrDefault(u => u.IsHeadOfDepartment()).Name,
                TotalSalaries = g.Sum(u => u.SalaryRecord.Last().Amount),
                MaxSalary = g.Max(u => u.SalaryRecord.Last().Amount),
                MinSalary = g.Min(u => u.SalaryRecord.Last().Amount)
            });

            return report;
        }
    }

    public class DepartmentReportResult
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int EmployeeCount { get; set; }
        public string HeadOfDepartmentName { get; set; }
        public decimal TotalSalaries { get; set; }
        public decimal MaxSalary { get; set; }
        public decimal MinSalary { set; get; }

        public override string ToString()
        {
            return $"--- {DepartmentName}:{DepartmentId}----\n" +
                   $"employee count = {EmployeeCount}\n" +
                   $"department head = {HeadOfDepartmentName}\n" +
                   $"department total salaries = {TotalSalaries}\n" +
                   $"department Max salaries = {MaxSalary}\n" +
                   $"department Min salaries = {MinSalary}\n";
        }

    }
}
