using LINQ_QUIZ.DataBase;
using LINQ_QUIZ.Models;

namespace LINQ_QUIZ.ReportsService
{
    internal class EmptyDepartmentsReport
    {
        public IEnumerable<Department> GenerateEmptyDepartmentReport()
        {
            IEnumerable<User> users = UserSource.GetAllUsers();

            var departments = users
                .Select(u => u.Department?.Name)
                .Distinct();

            var allDeptsNames = Department.GetAllDeptsNames();

            var emptyDeptsNames = allDeptsNames
                                 .Where(name => !departments.Contains(name));

            return emptyDeptsNames
                  .Select(deptName => Department.GetDeptByName(deptName));
        }
    }
}
