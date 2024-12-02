using System;
class Program
{
    static void Main(string[] args)
    {
        const string introWidth = "Introdueix l'amplada del rectangle:";
        const string introHeight = "Introdueix l'altura del rectangle:";
        const string rectangleArea = "L'area del rectangle es: ";
        const string introRadius = "Introdueix el radi del cercle:";
        const string answCircumf = "La circumferencia del cercle es: ";
        const string areaOverFifty = "L'area es mes gran de 50";
        const string areaBetweenTwentyAndFifty = "L'area es entre 20 i 50";
        const string areaUnderTwenty = "L'area es menor o igual a 20";
        double width;
        double height;
        double area = 0;
        double radius;
        double circumference;
        Console.WriteLine(introWidth);
        width = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine(introHeight);
        height = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine(CalculateArea(ref area, width, height, rectangleArea));
        Console.WriteLine(introRadius);
        radius = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine(CalculateCircumference(circumference, radius, answCircumf));
        Console.WriteLine(AreaRange(area, areaOverFifty, areaBetweenTwentyAndFifty, areaUnderTwenty));
    }
    public static string CalculateArea(ref double area, double width, double height, string rectangleArea){
        area = width * height;
        return (rectangleArea + area);
    }
    public static string CalculateCircumference(double circumference, double radius, string answCircumf){
        circumference = 2 * Math.PI * radius;
        return (answCircumf + circumference);
    }
    public static string AreaRange(double area, string areaOverFifty, string areaBetweenTwentyAndFifty, string areaUnderTwenty){
        if (area > 50)
        {
            return areaOverFifty;
        }
        else if (area > 20)
        {
            return areaBetweenTwentyAndFifty;
        }
        else
        {
            return areaUnderTwenty;
        }
    }
}
