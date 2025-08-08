using System;


class ExcetonHandeling
{

    public static void Run()
    {
        int n1 = int.Parse(Console.ReadLine());
        int n2 = int.Parse(Console.ReadLine());


        try
        {
            var dk = n1 / n2;
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("cant divided by zero");
        }
        finally
        {
            Console.WriteLine("show  no matter what");
        }

    }

}