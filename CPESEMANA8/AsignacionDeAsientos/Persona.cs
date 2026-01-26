using System;

namespace SistemaParque
{
    public class Visitante
    {
        public string Nombre { get; private set; }
        public int Turno { get; private set; }

        public Visitante(string nombre, int turno)
        {
            Nombre = nombre;
            Turno = turno;
        }

        public string ObtenerDatos()
        {
            return $"Turno {Turno} - {Nombre}";
        }
    }
}
