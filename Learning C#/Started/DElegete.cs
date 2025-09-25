using System;

delegate double CalculeteCircleArea(double area);


class MASA
{
    public static void Run()
    {
        CalculeteCircleArea circle = GetArea;

        double r = circle(5.34);

        Console.WriteLine($"THe area of circlle is: {r}");
     }

    public static double GetArea(double r)
    {
        return 3.1416 * (r * r);
    }
}