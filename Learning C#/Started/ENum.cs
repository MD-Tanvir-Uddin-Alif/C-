using System;

enum seasion
{
    summer = 1,
    Winter = 2,
    autumn = 3,
    spring = 4,
}

namespace Name
{
    public class ENUM
    {
        public void Run()
        {
            Console.WriteLine("Enter an seasion");
            string name = Console.ReadLine();

            seasion value;

            bool ok = Enum.TryParse(name, true, out value);

            if (ok)
            {
                if (value == seasion.autumn) Console.WriteLine("canadian leaf");
                else if (value == seasion.spring) Console.WriteLine("finally its spring");
                else if (value == seasion.summer) Console.WriteLine("Ahhh... so hot");
                else Console.WriteLine("so cold ....");
            }
            else Console.WriteLine("something went wrong");
        }
    }
}