using System;

namespace Name
{
    public class ArrayRevize
    {
        public static void Run()
        {
            Console.WriteLine("Entr the number");
            int n = int.Parse(Console.ReadLine());


            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            foreach (int i in arr)
            {
                if (i % 2 == 0) Console.WriteLine($"{i} is an even number");
                else Console.WriteLine($"{i} is an odd number");
            }
        }
    }
}