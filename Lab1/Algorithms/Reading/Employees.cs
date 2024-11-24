namespace Reading
{
    public class Employees
    {
        public static readonly string rootFolder = @"C:\Users\jovan\OneDrive\Desktop\FSU600\Lab1\Algorithms";
        public static readonly string employeeFile = @"C:\Users\jovan\OneDrive\Desktop\FSU600\Lab1\Algorithms\Employees.txt";
        public static void filterMain(string[] args)
        {
            if( File.Exists(employeeFile) )
            {
                string employees = File.ReadAllText(args[0]);
                Console.WriteLine(employees);
            }
            else
            {
                Console.WriteLine("File Does Not Exist");
            }
           
        }
    }
}
