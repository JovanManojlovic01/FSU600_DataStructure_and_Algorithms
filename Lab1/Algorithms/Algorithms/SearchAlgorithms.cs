using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Algorithms.SortingAlgorithms;

namespace Algorithms
{
    public class SearchAlgorithms
    {
        public delegate int searchDelegate(int[] myArray, int key);
        public static void Randomize(int[] randomNumbers)
        {
            Random random = new Random();
            for (int i = 0; i < randomNumbers.Length; i++)
            {
                randomNumbers[i] = random.Next(0, 10 * randomNumbers.Length);
            }
        }

        public static int[] Prepare(int n)
        {
            int[] myArray = new int[n];
            Randomize(myArray);
            return myArray;
        }

        public static int LinearSearch(int[] myArray, int key) // Code from tutorials.eu
        {
            for (int i = 0; i < myArray.Length; i++)
            {
                if (myArray[i] == key)
                {
                    return i; 
                }
            }
            return -1; 
        }

        
        public static int IterativeBinarySearch(int[] myArray, int key) // Code from c-sharpcorner.com
        {
            int min = 0;
            int max = myArray.Length - 1;

            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (key == myArray[mid])
                {
                    return mid; 
                }
                else if (key < myArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1; 
        }

        public static int LambdaSearch(int[] myArray, int key)
        {
            return Array.FindIndex(myArray, x => x == key);
        }

        public static async Task<double> DisplayRunningTime(int[] myArray, int key, searchDelegate searchDelegate)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int result = await Task.Run(() => searchDelegate(myArray, key));
            stopWatch.Stop();
            TimeSpan timeSpan = stopWatch.Elapsed;
            Console.WriteLine($"{timeSpan}");
            return timeSpan.TotalMilliseconds; // Return time in milliseconds
        }
    }
}
