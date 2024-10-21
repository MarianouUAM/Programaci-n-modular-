using System;
using System.Collections.Generic;
using System.Linq;

namespace GestionCalificaciones
{
    internal class Program
    {
        //Agrega estudiantes y notas
        public static void AgregarEstudiante(Dictionary<string, List<double>> estudiantes, string nombre, List<double> calificaciones)
        {
            estudiantes[nombre] = calificaciones;
            Console.WriteLine($"Estudiante {nombre} agregado/a con calificaciones: {string.Join(", ", calificaciones)}");
        }

        // Calcula el promedio
        public static double CalcularPromedio(List<double> calificaciones)
        {
            if (calificaciones.Count == 0)
                return 0;

            double suma = calificaciones.Sum();
            return suma / calificaciones.Count;
        }

        // determina quien tiene mayor y menor promedio 
        public static void DeterminarMejorPeorEstudiante(Dictionary<string, List<double>> estudiantes)
        {
            if (estudiantes.Count == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
                return;
            }

            string mejorEstudiante = "";
            string peorEstudiante = "";
            double mejorPromedio = double.MinValue;
            double peorPromedio = double.MaxValue;

            foreach (var estudiante in estudiantes)
            {
                double promedio = CalcularPromedio(estudiante.Value);

                if (promedio > mejorPromedio)
                {
                    mejorPromedio = promedio;
                    mejorEstudiante = estudiante.Key;
                }

                if (promedio < peorPromedio)
                {
                    peorPromedio = promedio;
                    peorEstudiante = estudiante.Key;
                }
            }

            Console.WriteLine($"\nEl estudiante con el mejor promedio es {mejorEstudiante} con un promedio de {mejorPromedio:F2}");
            Console.WriteLine($"El estudiante con el peor promedio es {peorEstudiante} con un promedio de {peorPromedio:F2}");
        }

        static void Main(string[] args)
        {
            Dictionary<string, List<double>> estudiantes = new Dictionary<string, List<double>>();
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\n--- Menú de Gestión de Calificaciones ---");
                Console.WriteLine("1. Agregar estudiante y sus calificaciones");
                Console.WriteLine("2. Calcular el promedio de un estudiante");
                Console.WriteLine("3. Determinar el mejor y peor estudiante");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Introduzca el nombre del estudiante: ");
                        string nombre = Console.ReadLine();
                        Console.Write("¿Cuántas calificaciones desea ingresar?: ");
                        int cantidadCalificaciones = int.Parse(Console.ReadLine());
                        List<double> calificaciones = new List<double>();

                        for (int i = 0; i < cantidadCalificaciones; i++)
                        {
                            Console.Write($"Ingrese la calificación {i + 1}: ");
                            double calificacion = double.Parse(Console.ReadLine());
                            calificaciones.Add(calificacion);
                        }

                        AgregarEstudiante(estudiantes, nombre, calificaciones);
                        break;

                    case "2":
                        Console.Write("Ingrese el nombre del estudiante para calcular su promedio: ");
                        string nombreEstudiante = Console.ReadLine();

                        if (estudiantes.ContainsKey(nombreEstudiante))
                        {
                            double promedio = CalcularPromedio(estudiantes[nombreEstudiante]);
                            Console.WriteLine($"El promedio de {nombreEstudiante} es: {promedio:F2}");
                        }
                        else
                        {
                            Console.WriteLine("Estudiante no encontrado.");
                        }
                        break;

                    case "3":
                        DeterminarMejorPeorEstudiante(estudiantes);
                        break;

                    case "4":
                        continuar = false;
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            } 
        }
    }
}

