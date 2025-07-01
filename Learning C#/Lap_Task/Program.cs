using System;

class Program {
    static void Main() {
        Console.Write("Enter X coordinate: ");
        int x = int.Parse(Console.ReadLine());

        Console.Write("Enter Y coordinate: ");
        int y = int.Parse(Console.ReadLine());

        if (x > 0 && y > 0)
            Console.WriteLine("Quadrant I");
        else if (x < 0 && y > 0)
            Console.WriteLine("Quadrant II");
        else if (x < 0 && y < 0)
            Console.WriteLine("Quadrant III");
        else if (x > 0 && y < 0)
            Console.WriteLine("Quadrant IV");
        else if (x == 0 && y == 0)
            Console.WriteLine("Origin");
        else if (x == 0)
            Console.WriteLine("Y-Axis");
        else
            Console.WriteLine("X-Axis");
    }
}
