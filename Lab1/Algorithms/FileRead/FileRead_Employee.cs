
using FileRead;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRead
{
    public class FileRead_Employee
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("------------------------------ File Reading ----------------------------------------------");
                Console.WriteLine("-----------------------------------------------------------------------------------");
                Console.WriteLine("Please enter the name of the action you want to do. Here is the list of available actions:");
                Console.WriteLine("1. Filter");
                Console.WriteLine("2. Map (Employee Names)");
                Console.WriteLine("3. Map (Departments)");
                Console.WriteLine("4. Reduce");
                Console.WriteLine("5. Exit");
                Console.WriteLine("-----------------------------------------------------------------------------------");

                string filereadName = Console.ReadLine();
                if (filereadName == "5" || filereadName == "Exit")
                {
                    Console.WriteLine("Exiting...");
                    Environment.Exit(0);
                }

                string filePath = @"C:\Users\jovan\OneDrive\Desktop\FSU600\Lab1\Algorithms\bin\Debug\net8.0\Employees.txt";


                switch (filereadName)
                {
                    case "1":
                        Console.WriteLine("You have chosen the filter function");
                        var filteredNames = EmployeeProcessor.filterEmployees(filePath, "an");
                        Console.WriteLine("\nList of filtered names that contain 'an' in their name/last name:");
                        filteredNames.ForEach(Console.WriteLine);
                        break;

                    case "2":
                        Console.WriteLine("You have chosen the map function for the employee names");
                        var employeeNames = EmployeeProcessor.MapEmployeeNames(filePath);
                        Console.WriteLine("\nAll employee names:");
                        employeeNames.ForEach(Console.WriteLine);
                        break;

                    case "3":
                        Console.WriteLine("You have chosen the map function for the employees departments");
                        var employeeDepartments = EmployeeProcessor.MapEmployeeDepartment(filePath);
                        Console.WriteLine("\nDepartments where employees work:");
                        employeeDepartments.ForEach(Console.WriteLine);
                        break;

                    case "4":
                        Console.WriteLine("You have chosen the reduce function");
                        int totalYearsOfExperience = EmployeeProcessor.reduceYearsOfExperience(filePath);
                        Console.WriteLine($"\nTotal years of experience between all the employees: {totalYearsOfExperience} years");
                        break;

                    default:
                        Console.WriteLine("You have written an invalid selection. Please try again.");
                        break;
                }
            }
        }
    }
}
