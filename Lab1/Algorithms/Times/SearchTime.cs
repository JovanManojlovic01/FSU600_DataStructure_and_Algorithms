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
            int averageCase = myArray[myArray.Length / 2];
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
                        RunAllTests(myArray, worstCase, averageCase, bestCase, searchDelegate);
                        break;

                    case "2":
                        Console.WriteLine("You have chosen Iterative Binary Search.");
                        searchDelegate = new searchDelegate(IterativeBinarySearch);
                        RunAllTests(myArray, worstCase, averageCase, bestCase, searchDelegate);
                        break;

                    case "3":
                        Console.WriteLine("You have chosen Lambda Search.");
                        searchDelegate = new searchDelegate(LambdaSearch);
                        RunAllTests(myArray, worstCase, averageCase, bestCase, searchDelegate);
                        break;

                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        continue;
                }
            }
        }

        public static void RunAllTests(int[] myArray, int worstCase, int averageCase, int bestCase, searchDelegate searchDelegate)
        {
            const int repetitions = 3; // Number of times to repeat each test

            double worstTime = RunTestMultipleTimes(myArray, worstCase, "Worst Case", repetitions, searchDelegate);
            double averageTime = RunTestMultipleTimes(myArray, averageCase, "Average Case", repetitions, searchDelegate);
            double bestTime = RunTestMultipleTimes(myArray, bestCase, "Best Case", repetitions, searchDelegate);

            Console.WriteLine("-----------------Final Results-------------------");
            Console.WriteLine($"Worst Case: {worstTime} ms");
            Console.WriteLine($"Average Case: {averageTime} ms");
            Console.WriteLine($"Best Case: {bestTime} ms");
        }

        public static double RunTestMultipleTimes(int[] myArray, int key, string caseType, int repetitions, searchDelegate searchDelegate)
        {
            double totalTime = 0;

            for (int i = 0; i < repetitions; i++)
            {
                Console.WriteLine($"Repetition {i + 1} for {caseType}...");
                totalTime += SearchAlgorithms.DisplayRunningTime(myArray, key, searchDelegate).GetAwaiter().GetResult(); // Here until the entire program is fixed.
            }

            double averageTime = totalTime / repetitions;
            Console.WriteLine($"{caseType} Average Time: {averageTime} ms");
            return averageTime;
        }
    }
}
