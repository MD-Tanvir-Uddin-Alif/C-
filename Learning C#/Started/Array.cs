using System;

namespace Name
{
    public class Array
    {
        public void array()
        {
            Console.WriteLine("Enter the arry size");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            Console.WriteLine("Enter the value of array");

            for (int i = 0; i < n; i++)
            {

                arr[i] = int.Parse(Console.ReadLine());
            }

            int l = 0, r = arr.Length - 1;

            while (l < r)
            {
                int temp = arr[l];
                arr[l] = arr[r];
                arr[r] = temp;

                l++;
                r--;
            }

            Console.WriteLine("Here is the revirsed elements");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}