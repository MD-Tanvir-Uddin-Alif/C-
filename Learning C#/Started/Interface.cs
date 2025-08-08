using System;

public interface IAthlete
{
    void PlaySport();
}

public interface IMusician
{
    void PlayInstrument();
}

public class Person : IAthlete, IMusician
{
    public string Name { get; set; }

    public void PlaySport()
    {
        Console.WriteLine($"{Name} is playing football.");
    }

    public void PlayInstrument()
    {
        Console.WriteLine($"{Name} is playing guitar.");
    }
}