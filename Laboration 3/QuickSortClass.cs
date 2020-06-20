using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class QuickSortClass
    {
        //Setting the length of the subarrays 
        public int Length { get; set; } = 10;
        public int[] QuickSortArray { get; set; }
        //Partition of the array
        int Partition(int[] array, int left, int right)
        {
            // Pick rightmost element as pivot from the array
            int pivot = array[right];

            // elements less than pivot will be pushed to the left of pIndex
            // elements more than pivot will be pushed to the right of pIndex
            // equal elements can go either way
            int pIndex = left;

            // each time we finds an element less than or equal to pivot, pIndex
            // is incremented and that element would be placed before the pivot.
            for (int i = left; i < right; i++)
            {
                if (array[i] <= pivot)
                {
                    var temp = array[i];
                    array[i] = array[pIndex];
                    array[pIndex] = temp;
                    pIndex++;
                }
            }
            // swap pIndex with Pivot
            var swapTemp = array[pIndex];
            array[pIndex] = array[right];
            array[right] = swapTemp;

            // return pIndex (index of pivot element)
            return pIndex;
        }

        // Quicksort routine
        public void quicksortWithInsertionSort(int[] array, int left, int right)
        {
            // base condition - if segment has only one element and exits function to avoid infinite recursive calls
            if (left >= right)
                return;
            //If the elements of the subarray are greater than 10
            else if (array.Length > Length)
            {
                // rearrange the elements across pivot
                int pivot = Partition(array, left, right);

                // recur on sub-array containing elements that are less than pivot
                quicksortWithInsertionSort(array, left, pivot - 1);

                // recur on sub-array containing elements that are more than pivot
                quicksortWithInsertionSort(array, pivot + 1, right);

                QuickSortArray = array;
            }
            //Else do the insertion Sort
            else
            {
                //Insertion Sort
                for (int i = 0; i < right - 1; i++)
                {
                    for (int j = i + 1; j > left + 1; j--)
                    {
                        if (array[j - 1] > array[j])
                        {
                            int temp = array[j - 1];
                            array[j - 1] = array[j];
                            array[j] = temp;
                        }
                    }
                }
            }
        }

        //Quick sort without the insertion sort for elements less than 10
        public void quicksort(int[] array, int left, int right)
        {
            // base condition
            if (left >= right)
                return;
            // rearrange the elements across pivot
            int pivot = Partition(array, left, right);
            // recur on sub-array containing elements that are less than pivot
            quicksort(array, left, pivot - 1);
            // recur on sub-array containing elements that are more than pivot
            quicksort(array, pivot + 1, right);

            QuickSortArray = array;
        }

    }
}
