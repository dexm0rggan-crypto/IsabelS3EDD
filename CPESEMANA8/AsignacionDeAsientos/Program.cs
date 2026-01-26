using System;

namespace SistemaParque
{
    class Aplicacion
    {
        static void Main(string[] args)
        {
            JuegoMecanico juego = new JuegoMecanico(30);
            int opcion = 0;

            while (opcion != 4)
            {
                Console.WriteLine("\n=== SISTEMA DE ASIGNACIÓN DE ASIENTOS ===");
                Console.WriteLine("1. Registrar visitante");
                Console.WriteLine("2. Ver lista de asignados");
                Console.WriteLine("3. Ver disponibilidad");
                Console.WriteLine("4. Salir");
                Console.Write("Opción: ");

                int.TryParse(Console.ReadLine(), out opcion);

                switch (opcion)
                {
                    case 1:
                        Console.Write("Nombre del visitante: ");
                        string nombre = Console.ReadLine();
                        juego.RegistrarVisitante(nombre);
                        break;

                    case 2:
                        juego.ListarAsignados();
                        break;

                    case 3:
                        juego.MostrarDisponibilidad();
                        break;

                    case 4:
                        Console.WriteLine("Programa finalizado.");
                        break;

                    default:
                        Console.WriteLine("Opción incorrecta.");
                        break;
                }
            }
        }
    }
}
