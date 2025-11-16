using LINQ_QUIZ.DataBase;
using LINQ_QUIZ.Models;

namespace LINQ_QUIZ.ReportsService
{
    internal class HeadOfEachDepartmentReport
    {
        public IEnumerable<(Department department, User user)> GenerateHeadOfEachDepartmentReport()
        {
            IEnumerable<User> users = UserSource.GetAllUsers();
            var heads = users.Where(u => u.IsHeadOfDepartment());

            return heads.Select(h => (h.Department!, h));
        }
    }
}
