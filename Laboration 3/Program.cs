using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Program
    {

        static void Main(string[] args)
        {
            //#region Quick Sort

            //DateTime now = DateTime.Now;
            //int[] array = { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            //DateTime starTime = DateTime.Now;
            //QuickSortClass classQuicksort = new QuickSortClass();
            //DateTime endTime = DateTime.Now;
            //TimeSpan time = endTime - starTime;

            //starTime = DateTime.Now;
            //classQuicksort.quicksortWithInsertionSort(array, 0, array.Length - 1);
            //endTime = DateTime.Now;
            //time = endTime - starTime;
            //Console.WriteLine($"Total Milliseconds for Quick Sort With Insertion Sort: {time.TotalMilliseconds}");

            //starTime = DateTime.Now;
            //classQuicksort.quicksort(array, 0, array.Length - 1);
            //endTime = DateTime.Now;
            //Console.WriteLine($"Total Milliseconds for Quick Sort: {(endTime - starTime).TotalMilliseconds}");

            //RandomizedPivot pivot = new RandomizedPivot();
            //starTime = DateTime.Now;
            //pivot.QuickSort(array, 0, array.Length - 1);
            //DateTime end = DateTime.Now;
            //Console.WriteLine($"Total Milliseconds with Quick Sort with Median Pivot:{(end - starTime).TotalMilliseconds}");
            //Console.ReadLine();

            //#endregion

            //Push done in constant time O(1)
            #region Custom Stack For Integers
            CustomStack stack = new CustomStack(3);

            stack.Push(911);
            stack.Push(20);
            stack.Push(435);
            stack.Push(429);
            stack.Push(511);
            stack.Push(12);
            stack.Push(772);
            stack.Push(435);
            stack.Push(0);
            stack.Push(112);
            stack.Push(11);
            stack.Push(1);
            stack.Push(11);
            stack.Push(25);
            stack.Push(244);
            stack.Push(55);
            stack.Push(99);
            stack.Push(15);
            stack.Push(30);
            stack.Push(17);



            DateTime startTime = DateTime.Now;
            stack.SortAscending();
            DateTime endTime = DateTime.Now;
            Console.WriteLine($"Time taken by Merge Sort to Display the Values for a collection 10 numbers: {(endTime - startTime).TotalMilliseconds}");

            startTime = DateTime.Now;
            stack.SortDescending();
            endTime = DateTime.Now;
            Console.WriteLine($"Time taken by Selection Sort Sort to Display the Values for a collection 10 numbers: {(endTime - startTime).TotalMilliseconds}");

            Console.ReadLine();
            #endregion
        }
    }
}
