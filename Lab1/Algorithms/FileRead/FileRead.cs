using System.Runtime.CompilerServices;

namespace FileRead
{
    public class EmployeeProcessor
    {
        public class Employee
        {
            public string employee_Name
            {
                get;
                set;
            }
            public string employee_Department
            {
                get;
                set;
            }
            public int employee_YearsOfExperience
            {
                get;
                set;
            }
        }

        public static Employee ParseEmployee(string line)
        {
            var parts = line.Split('|', StringSplitOptions.RemoveEmptyEntries);
            return new Employee
            {
                employee_Name = parts[0].Trim(),
                employee_Department = parts[1].Trim(),
                employee_YearsOfExperience = int.Parse(parts[2].Trim())
            };
        }

        public static List<string> filterEmployees(string filePath, string substring)
        {
            return (List<string>)File.ReadAllLines(filePath)
                .Where(line => !string.IsNullOrEmpty(line))
                .Select(line => ParseEmployee(line))
                .Where(i =>i.employee_Name.Contains(substring, StringComparison.OrdinalIgnoreCase))
                .Select(i => i.employee_Name)
                .ToList();
        }

        public static List<string> MapEmployeeNames(string filePath)
        {
            return (List<string>)File.ReadAllLines(filePath)
                .Where(line => !string.IsNullOrEmpty(line))
                .Select(line => ParseEmployee(line))
                .Select(i => i.employee_Name)
                .ToList();
        }

        public static List<string> MapEmployeeDepartment(string filePath)
        {
            return (List<string>)File.ReadAllLines(filePath)
                .Where(line => !string.IsNullOrEmpty(line))
                .Select(line => ParseEmployee(line))
                .Select(i => i.employee_Department)
                .ToList();
        }

        public static int reduceYearsOfExperience(string filePath)
        {
            return File.ReadAllLines(filePath)
                .Where(line => !string.IsNullOrWhiteSpace(line)) 
                .Select(line => ParseEmployee(line))            
                .Select(employee => employee.employee_YearsOfExperience)
                .Sum();                                         
        }
    }
}
