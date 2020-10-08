using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Persona
    {
        public long Documento { get; set; }
        public string Nombre { get; set; }
        public int SemanasCotizadas { get; set; }
        public string Tipo { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }

        public Persona(long documento, string nombre, int semanasCotizadas, string tipo, string sexo, int edad)
        {
            Documento = documento;
            Nombre = nombre;
            SemanasCotizadas = semanasCotizadas;
            Tipo = tipo;
            Sexo = sexo;
            Edad = edad;
        }

    }
}
