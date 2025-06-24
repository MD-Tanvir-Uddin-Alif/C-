using System;
using System.Collections.Generic;


namespace Name
{
    public class MyList
    {
        public void Run()
        {
            var list = new List<int>();

            Console.WriteLine("How many element you want to add in the List");
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter The elements of the List");

            for (int i = 0; i < num; i++)
            {
                int value = int.Parse(Console.ReadLine());
                list.Add(value);
            }

            Console.WriteLine("here is the element of the list");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}