using System;
using System.Collections.Generic;

namespace VacunacionCovid
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear lista de 500 ciudadanos
            List<string> ciudadanos = new List<string>();

            for (int i = 1; i <= 500; i++)
            {
                ciudadanos.Add("Habitante " + i);
            }

            // Crear conjuntos de vacunados
            HashSet<string> pfizer = new HashSet<string>();
            HashSet<string> astraZeneca = new HashSet<string>();

            Random random = new Random();

            // Asignar 75 vacunados Pfizer
            while (pfizer.Count < 75)
            {
                int numero = random.Next(0, ciudadanos.Count);
                pfizer.Add(ciudadanos[numero]);
            }

            // Asignar 75 vacunados AstraZeneca
            while (astraZeneca.Count < 75)
            {
                int numero = random.Next(0, ciudadanos.Count);
                astraZeneca.Add(ciudadanos[numero]);
            }

         
            // OPERACIONES DE CONJUNTOS
          

            HashSet<string> noVacunados = new HashSet<string>(ciudadanos);
            noVacunados.ExceptWith(pfizer);
            noVacunados.ExceptWith(astraZeneca);

            HashSet<string> ambasDosis = new HashSet<string>(pfizer);
            ambasDosis.IntersectWith(astraZeneca);

            HashSet<string> soloPfizer = new HashSet<string>(pfizer);
            soloPfizer.ExceptWith(astraZeneca);

            HashSet<string> soloAstra = new HashSet<string>(astraZeneca);
            soloAstra.ExceptWith(pfizer);

            // Mostrar resultados
            Console.WriteLine("RESULTADOS DE LA CAMPAÑA DE VACUNACIÓN\n");

            Console.WriteLine("1) No vacunados: " + noVacunados.Count);
            foreach (string persona in noVacunados)
            {
                Console.WriteLine(persona);
            }

            Console.WriteLine("\n2) Ambas dosis: " + ambasDosis.Count);
            foreach (string persona in ambasDosis)
            {
                Console.WriteLine(persona);
            }

            Console.WriteLine("\n3) Solo Pfizer: " + soloPfizer.Count);
            foreach (string persona in soloPfizer)
            {
                Console.WriteLine(persona);
            }

            Console.WriteLine("\n4) Solo AstraZeneca: " + soloAstra.Count);
            foreach (string persona in soloAstra)
            {
                Console.WriteLine(persona);
            }

            Console.WriteLine("\nPresione una tecla para salir...");
            Console.ReadKey();
        }
    }
}