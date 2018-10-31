using System;
/*Given a sorted array of n integers that has been rotated an unknown number of times, 
 * write code to find an element in the array. 
 * You may assume that the array was originally sorted in increasing order.
 * */
namespace Array3
{
    class Program
    {
        static int searchElement(int[] arr, int start, int end, int key)
        {
            if (start > end)
                return -1;
            int mid = (start + end) / 2;
            if (arr[mid] == key)
                return mid;

            //check the left side
            if (arr[start] <= arr[mid])  //sorted
            {
                if (key >= arr[start] && key < arr[mid])
                    return searchElement(arr, start, mid - 1, key);
                return searchElement(arr, mid + 1, end, key);
            }
            else
            {
                //if left side is not sorted
                //then right side is sorted
                if (key > arr[mid] && key <= arr[end])
                    return searchElement(arr, mid + 1, end, key);
                return searchElement(arr, start, mid - 1, key);
            }
            return -1;
        }

        static void Main(string[] args)
        {
            int[] arr = { 17, 18, 20, 1, 2, 3, 4, 5, 6, 7, 8, 9, 12 };
            int n = arr.Length;
            int key = 1;
            int i = searchElement(arr, 0, n - 1, key);
            if (i != -1)
                Console.WriteLine("Index: " + i);
            else
                Console.WriteLine("Key not found");
        }
    }
}
