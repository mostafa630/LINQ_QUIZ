using LINQ_QUIZ.DataBase;
using LINQ_QUIZ.Models;

namespace LINQ_QUIZ.ReportsService
{
    internal class TotalSalariesReport
    {
        public decimal GenerateTotalSalariesReport()
        {
            IEnumerable<User> users = UserSource.GetAllUsers();
            return users.Sum(u => u.SalaryRecord.Last().Amount);
        }
    }
}
