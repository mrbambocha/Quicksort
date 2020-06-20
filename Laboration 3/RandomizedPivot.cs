using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class RandomizedPivot
    {
        public int[] FinalArrayToBeDisplayed { get; set; }
        int Partition(int[] ArrayToBeParitioned, int Left, int Start)
        {
            // Pick rightmost element as pivot from the array
            int pivot = ArrayToBeParitioned[Start];

            // elements less than pivot will be pushed to the left of pivotIndex
            // elements more than pivot will be pushed to the right of pivotIndex
            // equal elements can go either way
            int PivotIndex = Left;

            // each time we finds an element less than or equal to pivot, pivotIndex
            // is incremented and that element would be placed before the pivot. 
            for (int i = Left; i < Start; i++)
            {
                if (ArrayToBeParitioned[i] <= pivot)
                {
                    var temp = ArrayToBeParitioned[i];
                    ArrayToBeParitioned[i] = ArrayToBeParitioned[PivotIndex];
                    ArrayToBeParitioned[PivotIndex] = temp;
                    PivotIndex++;
                }
            }
            // swap PivotIndex with Pivot
            var swapTemp = ArrayToBeParitioned[PivotIndex];
            ArrayToBeParitioned[PivotIndex] = ArrayToBeParitioned[Start];
            ArrayToBeParitioned[Start] = swapTemp;

            // return PivotIndex (index of pivot element)
            return PivotIndex;
        }

        int RandomizedPartition(int[] Array, int start, int end)
        {
            // choose the median as random index
            int pivotIndex = Array[(start + end) / 2];

            // swap the end element with element present at median index
            var temp = Array[pivotIndex];
            Array[pivotIndex] = Array[end];
            Array[end] = temp;
            // call partition procedure
            return Partition(Array, start, end);
        }

        // Quicksort routine
        public void QuickSort(int[] Array, int start, int end)
        {
            // base condition
            if (start >= end)
                return;

            // rearrange the elements across pivot
            int pivot = RandomizedPartition(Array, start, end);

            // recur on sub-array containing elements that are less than pivot
            QuickSort(Array, start, pivot - 1);

            // recur on sub-array containing elements that are more than pivot
            QuickSort(Array, pivot + 1, end);

            FinalArrayToBeDisplayed = Array;
        }

    }
}
