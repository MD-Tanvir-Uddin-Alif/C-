using System;

namespace Name
{
    class dicit
    {
        public void RUn()
        {
            Dictionary<string, int> student = new Dictionary<string, int>();

            Console.WriteLine("how many student you want to enter");
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                Console.WriteLine($"Enter the name and marks for studen: {i} ");
                string name = Console.ReadLine();
                int marks = int.Parse(Console.ReadLine());

                student[name] = marks;
            }

            Console.WriteLine("Enter the name of the student you want to know: ");
            string stu_name = Console.ReadLine();

            if (student.ContainsKey(stu_name)) Console.WriteLine(student[stu_name]);
            else Console.WriteLine("Not found ");

            foreach (var pair in student) Console.WriteLine($"{pair.Key} mark is {pair.Value}");
        }
    }
}