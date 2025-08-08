using System;

abstract class Animal
{
    public string Name { get; set; }

    public Animal(string name)
    {
        Name = name;
    }

    public abstract void Communicate();
}

class Dog : Animal
{
    public Dog(string name) : base(name) { }

    public override void Communicate()
    {
        Console.WriteLine($"{Name} says: Bark!");
    }
}

class Cat : Animal
{
    public Cat(string name) : base(name) { }

    public override void Communicate()
    {
        Console.WriteLine($"{Name} says: Meow!");
    }
}

class Cow : Animal
{
    public Cow(string name) : base(name) { }

    public override void Communicate()
    {
        Console.WriteLine($"{Name} says: Moo!");
    }
}

class Program
{
    static void Main()
    {
        Animal dog = new Dog("Dog");
        Animal cat = new Cat("Cat");
        Animal cow = new Cow("Cow");

        dog.Communicate();
        cat.Communicate();
        cow.Communicate();
    }
}
