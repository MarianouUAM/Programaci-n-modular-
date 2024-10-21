/*using System;
    public class AreaTriangulo
    {
        public static void Main (string[] args)
        {
        Console.WriteLine("Ingrese la base del triangulo");
        double baseT = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Ingrese la altura del triangulo");
        double alturaT = Convert.ToDouble(Console.ReadLine());  

        double res = Area(baseT, alturaT);
        Console.WriteLine($"El area del triangulo es: {res}");
        Console.ReadKey();
        }

         public static double Area(double x, double y)
        {
            return (x * y) / 2;

        }
        
    }*/

using System;
public class AreaTriangulo
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Ingrese la base del triangulo");
        double baseT = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Ingrese la altura del triangulo");
        double alturaT = Convert.ToDouble(Console.ReadLine());

        double res = 0;
        Area(ref baseT, ref alturaT, ref res);
        Console.WriteLine($"El area del triangulo es: {res}");
        Console.ReadKey();
    }

    public static void Area(ref double x, ref double y, ref double res)
    {
        res = ((x * y) / 2);

    }

}
