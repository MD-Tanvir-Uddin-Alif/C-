using System;

public delegate void Notify(string message);


class Program
{

    public static void Email(string mns)
    {
        Console.WriteLine("I am form Email");
    }

    public static void Phone(string mns)
    {
        Console.WriteLine("I am form phone");
    }
    public static void Main(string[] args)
    {
        Notify noti = Email;

        string a = Console.ReadLine();

        if (a == "email")
        {
            noti = Email;
        }
    }
}