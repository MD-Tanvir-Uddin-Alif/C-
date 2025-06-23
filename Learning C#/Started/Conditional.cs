using System;

namespace Name
{
    public class Conditional
    {
        public void show()
        {
            Console.WriteLine("How many number you wnat to play with?");
            int number = int.Parse(Console.ReadLine());
            int even=0, odd = 0;

            for (int i = 1; i <= number; i++)
            {
                Console.WriteLine($"Enter the number {i}");
                int n = int.Parse(Console.ReadLine());

                if (n % 2 == 0) even++;
                else odd++;


            }
            
            Console.WriteLine($"Even number is {even}, odd number is {odd}");
        }
    }
}