using System;


class CustomException : Exception
{
    public int age { get; set; }

    public CustomException(string message) : base(message) { }
}


class AmrException
{
    public static void Run()
    {
        int age = int.Parse(Console.ReadLine());
        try
        {
            validate(age);

        }
        catch(CustomException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

    }


    public static void validate(int age)
    {
        if (age < 20) throw new CustomException("age must be greater then 20");
    }
}
