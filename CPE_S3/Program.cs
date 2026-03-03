using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<string, HashSet<string>> campeonato =
        new Dictionary<string, HashSet<string>>(StringComparer.OrdinalIgnoreCase);

    static void Main(string[] args)
    {
        int opcionMenu = -1;

        while (opcionMenu != 0)
        {
            MostrarMenu();

            if (!int.TryParse(Console.ReadLine(), out opcionMenu))
            {
                Console.WriteLine("Debe ingresar un número válido.");
                continue;
            }

            if (opcionMenu == 1)
            {
                CrearEquipo();
            }
            else if (opcionMenu == 2)
            {
                IngresarJugador();
            }
            else if (opcionMenu == 3)
            {
                ListarDatos();
            }
            else if (opcionMenu == 0)
            {
                Console.WriteLine("Programa finalizado.");
            }
            else
            {
                Console.WriteLine("Opción incorrecta.");
            }
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("\n===== TORNEO DE FÚTBOL =====");
        Console.WriteLine("1 -> Añadir equipo");
        Console.WriteLine("2 -> Añadir jugador");
        Console.WriteLine("3 -> Ver torneo");
        Console.WriteLine("0 -> Salir");
        Console.Write("Seleccione: ");
    }

    static void CrearEquipo()
    {
        Console.Write("Nombre del equipo: ");
        string nombre = (Console.ReadLine() ?? "").Trim();

        if (string.IsNullOrWhiteSpace(nombre))
        {
            Console.WriteLine("No se permite nombre vacío.");
            return;
        }

        if (campeonato.ContainsKey(nombre))
        {
            Console.WriteLine("El equipo ya está registrado.");
        }
        else
        {
            campeonato.Add(nombre, new HashSet<string>(StringComparer.OrdinalIgnoreCase));
            Console.WriteLine("Equipo guardado correctamente.");
        }
    }

    static void IngresarJugador()
    {
        Console.Write("Equipo al que pertenece: ");
        string equipo = (Console.ReadLine() ?? "").Trim();

        if (!campeonato.ContainsKey(equipo))
        {
            Console.WriteLine("Ese equipo no existe.");
            return;
        }

        Console.Write("Nombre del jugador: ");
        string jugador = (Console.ReadLine() ?? "").Trim();

        if (string.IsNullOrWhiteSpace(jugador))
        {
            Console.WriteLine("Nombre inválido.");
            return;
        }

        bool agregado = campeonato[equipo].Add(jugador);

        if (agregado)
        {
            Console.WriteLine("Jugador añadido correctamente.");
        }
        else
        {
            Console.WriteLine("El jugador ya estaba en el equipo.");
        }
    }

    static void ListarDatos()
    {
        Console.WriteLine("\n--- LISTADO DEL TORNEO ---");

        if (campeonato.Count == 0)
        {
            Console.WriteLine("No hay equipos registrados todavía.");
            return;
        }

        foreach (var equipo in campeonato)
        {
            Console.WriteLine("\nEquipo: " + equipo.Key);

            if (equipo.Value.Count == 0)
            {
                Console.WriteLine("  Sin jugadores.");
            }
            else
            {
                foreach (var jugador in equipo.Value)
                {
                    Console.WriteLine("  * " + jugador);
                }
            }
        }
    }
}