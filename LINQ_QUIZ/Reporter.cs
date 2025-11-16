using LINQ_QUIZ.ReportsService;
public static class Reporter
{
    public static void DisplayDepartmentAndMonthTotalSalaryReport()
    {
        var report = new DepartmentAndMonthTotalSalaryReport();
        var res = report.GenerateDepartmentAndMonthTotalSalaryReport();

        Console.WriteLine("=== Department And Month Total Salary Report ===");
        foreach (var record in res)
        {
            Console.WriteLine(record);
        }
        Console.WriteLine();
    }

    public static void DisplayDepartmentReport()
    {
        var report = new DepartmentReport();
        var res = report.GenerateReport();

        Console.WriteLine("=== Department Report ===");
        foreach (var record in res)
        {
            Console.WriteLine(record);
        }
        Console.WriteLine();
    }

    public static void DisplayEmptyDepartmentsReport()
    {
        var report = new EmptyDepartmentsReport();
        var res = report.GenerateEmptyDepartmentReport();

        Console.WriteLine("=== Empty Departments Report ===");
        foreach (var record in res)
        {
            Console.WriteLine(record);
        }
        Console.WriteLine();
    }

    public static void DisplayHeadOfEachDepartmentReport()
    {
        var report = new HeadOfEachDepartmentReport();
        var res = report.GenerateHeadOfEachDepartmentReport();

        Console.WriteLine("=== Head Of Each Department Report ===");
        foreach (var record in res)
        {
            Console.WriteLine($"Head: {record.user}");
            Console.WriteLine($"Dept: {record.department}");
            Console.WriteLine("-------------------------");
        }
        Console.WriteLine();
    }

    public static void DisplayTotalSalariesReport()
    {
        var report = new TotalSalariesReport();
        var res = report.GenerateTotalSalariesReport();

        Console.WriteLine("=== Total Salaries Report ===");
        Console.WriteLine($"Total Salary = {res}");
        Console.WriteLine();
    }

    public static void DisplayAllReports()
    {
        DisplayDepartmentAndMonthTotalSalaryReport();
        DisplayDepartmentReport();
        DisplayEmptyDepartmentsReport();
        DisplayHeadOfEachDepartmentReport();
        DisplayTotalSalariesReport();
    }
}
