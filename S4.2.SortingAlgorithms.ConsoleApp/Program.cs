﻿using System;
using System.Collections.Generic;

namespace S4._2.SortingAlgorithms.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            int[] array = { 4, 1, 3, 2 };
            //SelectionSort(array);
            //for(int i = 0; i < array.Length; i++)
            //{
            //    Console.WriteLine(array[i]);
            //}
            BubbleSort(array);
            for(int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
         
        // A function to implement bubble sort.
        // Compares the last item with the one before it, & swaps them if they are not in the correct order. Repeats this process "n" times.
        private static void BubbleSort(int[] array)
        {
            // Iterate over the array, starting with the second element.
            for(int i = 1; i < array.Length; i++)
            {
                for(int j = array.Length - 1; j >= i; j--)
                {
                    // if two adjoining elements, are in the wrong order, swap them.
                    if(array[j] < array[j - 1])
                    {
                        // Code to swap, if item number "j - 1" is larger than item "j"
                        (array[j - 1], array[j]) = (array[j], array[j - 1]);
                    }
                    // Repeat above until end of array.
                }
            }
        }
            
        // Goes through the entire array to check if item "j" is in the correct spot. Repeats for every item.
        private static void InsertionSort(int[] array)
        {
            // Loop array skipping first element
            for(int i = 1; i < array.Length; i++)
            {

                int j = i;
                int t = array[j];
                //While item "j" is NOT ordered correctly, move it around the array until it is
                while(j > 0 && t < array[j - 1])
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = t;
                // Repeat above until end of array.
            }
        }

        // Finds the smallest item in the array, and puts it in the correct place. Repeats for all remaining unsorted items.
        private static void SelectionSort(int[] array)
        {
            for(int i = 0; i < array.Length - 1; i++)
            {
                int k = i;
                //Find smallest item in array.
                for(int j = i + 1; j < array.Length; j++)
                {
                    //If the current item is smaller than the first unordered item, swap the two items.
                    if(array[j] < array[k])
                    {
                        k = j;
                    }
                    (array[i], array[k]) = (array[k], array[i]);
                }
            }
        }

        private static void TreeSort(int[] array)
        {
            SortedSet<int> t = new();
            for(int i = 0; i < array.Length; i++)
            {
                t.Add(array[i]);
            }
            FillArray(t, array, 0);
        }


        private static int FillArray(SortedSet<int> t, int[] array, int j)
        {
            if(t.Count != 0)
            {
                j = FillArray(t, array, j);
                // array[j++] = root(t);
                //  j = FillArray(t.Max, array, j)
            }
            return j;
        }

        private static void HeapSort(int[] array)
        {
            //TODO
        }

        private static void QuickSort(int[] array, int left, int right)
        {
            if(left < right)
            {
                int pivotIndex = OtherPartition(array, left, right);
                QuickSort(array, left, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, right);
            }
        }

        private static int Partition(int[] array, int left, int right)
        {
            int pivotIndex = array[(array.Length - 1) / 2];
            int pivot = array[pivotIndex];
            (array[pivotIndex], array[right]) = (array[right], array[pivotIndex]);
            int leftMark = left;
            int rightMark = right - 1;
            while(leftMark <= rightMark)
            {
                while(leftMark <= rightMark && array[leftMark] <= pivot)
                {
                    leftMark++;
                }
                while(leftMark <= rightMark && array[rightMark] >= pivot)
                {
                    rightMark--;
                }
                if(leftMark < rightMark)
                {
                    (array[leftMark++], array[rightMark--]) = (array[rightMark--], array[leftMark++]);
                }
            }
            (array[leftMark], array[rightMark]) = (array[rightMark], array[leftMark]);
            return leftMark;
        }

        private static int OtherPartition(int[] array, int left, int right)
        {
            //Create new array half as long as the original array
            int[] newArray = new int[right - left + 1];

            //Find centre index of original array
            int pivotIndex = array[(array.Length - 1) / 2];
            int pivot = array[pivotIndex];
            int arrayCount = left;
            int newArrayCount = 1;
            // Loop array
            for(int i = left; i <= right; i++)
            {
                //If item "i" is the centre index, insert "i" into the new array as the first item.
                if(i == pivotIndex)
                {
                    newArray[0] = array[i];
                }
                //Else if item "i" is smaller than the centre item or is equal to the centre item while preceeding it, move the item to the front //half of the array.
                else if(array[i] < pivot || (array[i] == pivot && i < pivotIndex))
                {
                    array[arrayCount++] = array[i];
                }
                //Otherwise insert item "i" into the new array.
                else
                {
                    newArray[newArrayCount++] = array[i];
                }
            }
            for(int i = 0; i < newArrayCount; i++)
            {
                array[arrayCount++] = newArray[i];
            }
            return right - newArrayCount + 1;
        }

        private static void MergeSort(int[] array, int left, int right)
        {
            if(left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(array, left, mid);
                MergeSort(array, mid + 1, right);
                Merge(array, left, mid, right);
            }
        }

        private static void Merge(int[] array, int left, int mid, int right)
        {   
            int[] newArray = new int[right - left + 1];
            int newArrayCount = 0;
            int lCount = left;
            int rCount = mid + 1;
            while((lCount <= mid) && (rCount <= right))
            {
                if(array[lCount] <= array[rCount])
                {
                    newArray[newArrayCount++] = array[lCount++];
                }
                else
                {
                    newArray[newArrayCount++] = array[rCount++];
                }
            }
            if(lCount > mid)
            {
                while(rCount <= right)
                {
                    newArray[newArrayCount++] = array[rCount++];
                }
            }
            else
            {
                while(lCount <= mid)
                {
                    newArray[newArrayCount++] = array[lCount++];
                }
            }
            for(newArrayCount = 0; newArrayCount < right - left + 1; newArrayCount++)
            {
                array[left + newArrayCount] = newArray[newArrayCount];
            }
        }
    }
}