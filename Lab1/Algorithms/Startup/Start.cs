namespace Startup
{
    using Times;
    public class Start
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------- Algorithm Comparison and File Reading -----------");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Which algorithm types would you like to compare:");
            Console.WriteLine("1. Sorting Algorithms");
            Console.WriteLine("2. Search Algorithms");
            Console.WriteLine("3. File Reading");
            Console.WriteLine("-----------------------------------------------------");

            string choice = Console.ReadLine();
            if (choice == "1")
            {
                SortingTime.Main(args);
            }
            else if (choice == "2")
            {
                SearchTime.SearchTimeMain(args);
            }
            else if (choice == "3")
            {
                FileRead.FileRead_Employee.Main(args);
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}
