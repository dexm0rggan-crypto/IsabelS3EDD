using System;
using System.Collections.Generic;

namespace SistemaParque
{
    public class JuegoMecanico
    {
        private Queue<Visitante> fila;
        private int capacidad;
        private int turnoActual;

        public JuegoMecanico(int capacidadMaxima)
        {
            fila = new Queue<Visitante>();
            capacidad = capacidadMaxima;
            turnoActual = 1;
        }

        public void RegistrarVisitante(string nombre)
        {
            if (fila.Count == capacidad)
            {
                Console.WriteLine("No hay asientos disponibles.");
                return;
            }

            Visitante nuevo = new Visitante(nombre, turnoActual);
            fila.Enqueue(nuevo);
            turnoActual++;

            Console.WriteLine($"Visitante {nombre} registrado correctamente.");
        }

        public void ListarAsignados()
        {
            if (fila.Count == 0)
            {
                Console.WriteLine("No hay visitantes registrados.");
                return;
            }

            Console.WriteLine("\n--- LISTA DE ASIENTOS OCUPADOS ---");
            foreach (Visitante v in fila)
            {
                Console.WriteLine(v.ObtenerDatos());
            }
            Console.WriteLine($"Total asignados: {fila.Count}");
        }

        public void MostrarDisponibilidad()
        {
            Console.WriteLine($"Asientos ocupados: {fila.Count} de {capacidad}");
            Console.WriteLine($"Asientos disponibles: {capacidad - fila.Count}");
        }
    }
}
