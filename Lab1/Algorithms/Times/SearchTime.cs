using Algorithms;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using static Algorithms.SearchAlgorithms;
using static Algorithms.SortingAlgorithms;


namespace Times
{
    public class SearchTime
    {
        public static void SearchTimeMain(string[] args)
        {
            const int arraySize = 100000; // Fixed array size of 100,000 integers
            int[] myArray = SearchAlgorithms.Prepare(arraySize);
            Array.Sort(myArray); // Sorting beforehand for Binary Search because it can only work if the array is sorted

            int bestCase = myArray[0];
            int averageCase = myArray[myArray.Length / 2]; // Initiating for each case
            int worstCase = myArray[myArray.Length - 1];

            while (true)
            {
                Console.WriteLine("------------------------------ Search Algorithms ----------------------------------------------");
                Console.WriteLine("1. Linear Search");
                Console.WriteLine("2. Binary Search (Iterative)");
                Console.WriteLine("3. Lambda Expression Search");
                Console.WriteLine("4. Exit");
                Console.WriteLine("-----------------------------------------------------------------------------------");

                string algorithmName = Console.ReadLine();
                if (algorithmName == "4" || algorithmName == "Exit")
                {
                    Console.WriteLine("Exiting...");
                    break;
                }

                searchDelegate searchDelegate;

                switch (algorithmName)
                {
                    case "1":
                        Console.WriteLine("You have chosen Linear Search.");
                        searchDelegate = new searchDelegate(LinearSearch);
                        break;

                    case "2":
                        Console.WriteLine("You have chosen Iterative Binary Search.");
                        searchDelegate = new searchDelegate(IterativeBinarySearch);
                        break;

                    case "3":
                        Console.WriteLine("You have chosen Lambda Search");
                        searchDelegate = new searchDelegate(LambdaSearch);
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        continue;
                }

                // Run tests for each case
                const int repetitions = 3; // Number of times to repeat each test
                double bestTime = RunTestMultipleTimes(myArray, bestCase, "Best Case", repetitions, searchDelegate);
                double averageTime = RunTestMultipleTimes(myArray, averageCase, "Average Case", repetitions, searchDelegate);
                double worstTime = RunTestMultipleTimes(myArray, worstCase, "Worst Case", repetitions, searchDelegate);

                Console.WriteLine($"Best Case Time: {bestTime} ms");
                Console.WriteLine($"Average Case Time: {averageTime} ms");
                Console.WriteLine($"Worst Case Time: {worstTime} ms");
            }
        }

        public static double RunTestMultipleTimes(int[] myArray, int key, string caseType, int repetitions, searchDelegate searchDelegate)
        {
            double totalTime = 0;

            for (int i = 0; i < repetitions; i++)
            {
                totalTime += SearchAlgorithms.DisplayRunningTime(myArray, key, searchDelegate);
            }

            double averageTime = totalTime / repetitions;
            Console.WriteLine($"{caseType} Average Time: {averageTime} ms");
            return averageTime;
        }
    }
}