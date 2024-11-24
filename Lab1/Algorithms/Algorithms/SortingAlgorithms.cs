using System.Diagnostics;

namespace Algorithms
{
    public class SortingAlgorithms
    {
        public delegate void sortingDelegate(int[] myArray); // Creation of a delegate 'sortingDelegate' with a same parameter as the sorting algorithms below
        public static void Swap(int[] myArray, int m, int n)
        {
            int temp; // Creation of a temporary integer so we can temporarily store the value to perform the swap
            temp = myArray[m]; // We set the temp to be m from the array
            myArray[m] = myArray[n]; // We swap the m from the array to be the n from the array
            myArray[n] = temp; // At the end, n from the array becomes the value of temp
        }

        public static void Randomize(int[] randomNumbers)
        {
            Random random = new Random(); // Used for generation of random numbers that are needed

            for (int i = 0; i < randomNumbers.Length; i++) 
            {
                randomNumbers[i] = random.Next(0,10 * randomNumbers.Length); // Generate random numbers that are between 0 and 10 times as the length of the array
            }
        }

        public static int[] Prepare(int n)
        {
            int[] myArray = new int[n]; // Creation of an array 'myArray', with size n
            Randomize(myArray); // Using the method 'Randomize'
            return myArray;
        }

        

        public static void InsertionSort(int[] myArray) // Code from w3resource.com
        {
            for (int i = 0; i < myArray.Length;i++)
            {
                for (int j = i + 1; j > 0 && j < myArray.Length; j--)
                {
                    if (myArray[j - 1] > myArray[j])
                    {
                        int temp = myArray[j - 1];
                        myArray[j - 1] = myArray[j];
                        myArray[j] = temp;
                    }
                }
            }
        }

        public static void SelectionSort(int[] myArray) // Code from w3resource.com
        {
            int smallest;

            for (int i = 0; i <= myArray.Length -1; i++)
            {
                smallest = i;
                for (int index = i + 1; index < myArray.Length; index++)
                {
                    if(myArray[index] < myArray[smallest])
                    {
                        smallest = index;
                    }
                }
                Swap (myArray,i,smallest);
            }
        }

        public static void MergeSortHelper(int[] myArray, int left, int right) // Original code taken from geeksforgeeks.com, then modified by myself to work in here
        {
           if ( left < right)
           { 

            int mid = left + (right - left) / 2;

            // Recursive usage
            MergeSortHelper (myArray, left, mid);
            MergeSortHelper(myArray, mid + 1, right);

            // Finding the sizes of the two subarrays in the array to be merged
            int n1 = mid - left + 1;
            int n2 = right - mid;

            // Creating temporary arrays
            int[] Left = new int[n1];
            int[] Right = new int[n2];
            int i, j;

            for (i = 0; i < n1; ++i)
                Left[i] = myArray[left + i];
            for (j = 0; j < n2; ++j)
                Right[j] = myArray[mid + 1 + j];

            i = 0;
            j = 0;

            int k = left;
            while (i < n1 && j < n2)
            {
                if (Left[i] <= Right[j])
                {
                    myArray[k] = Left[i];
                    i++;
                }
                else
                {
                    myArray[k] = Right[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                myArray[k] = Left[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                myArray[k] = Right[j];
                j++;
                k++;
            }
           }
        }

        public static void MergeSort(int[] myArray)
        {
            MergeSortHelper(myArray, 0, myArray.Length - 1);
        }

        public static void BubbleSort(int[] myArray) // Code from dotnetttutorials.net
        {

            for (int j =0; j <= myArray.Length - 2; j++)
            {
                for (int i =0; i <= myArray.Length - 2; i++)
                {
                    if (myArray[i] > myArray[j])
                    {
                        Swap(myArray, i, i + 1);
                    }
                }
            }
        }

        public static int quicksortPartition(int[] myArray, int left, int right) // Original code was taken from w3resource.com, modified in order to fit in my case.
        {
            int pivot = myArray[left];

            while (true)
            {
                
                while (left <= right && myArray[left] < pivot) // Move left pointer to find an element greater than or equal to pivot
                {
                    left++;
                }

                
                while (right >= left && myArray[right] > pivot) // Move right pointer to find an element less than or equal to pivot
                {
                    right--;
                }


                if (left >= right) // If the pointers meet or cross eachother, we return the index of that partition
                {
                    return right;
                }

                
                Swap(myArray, left, right); // Using swap method to swap elements
                left++;
                right--;
            }
        }

        public static void quicksortHelper(int[] myArray, int left, int right)
        {
            if (left < right)
            {
                int partitionIndex = quicksortPartition(myArray, left, right);

                // Recursively sort elements on both sides
                quicksortHelper(myArray, left, partitionIndex);
                quicksortHelper(myArray, partitionIndex + 1, right);
            }
        }

        public static void QuickSort(int[] myArray)
        {
            quicksortHelper(myArray, 0, myArray.Length - 1);
        }

        public static int[] SortByLambda(int[] myArray)
        {
            int[] sortedArray = (int[])myArray.Clone(); // Creating a clone of the array to avoid mutations

            Array.Sort(sortedArray, (x, y) => x.CompareTo(y)); // Sorting the arrays in ascending order using lambda expression
            return sortedArray;
        }

        public static void DisplayRunningTime(int[] myArray, sortingDelegate sortingDelegate)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            sortingDelegate(myArray);
            stopWatch.Stop();
            TimeSpan timeSpan = stopWatch.Elapsed;
            Console.WriteLine(timeSpan);
        }
    }
}
