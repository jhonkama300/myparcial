using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DAL
{
    public class Repository
    {
        public static string direccionArchivo = "Repository.txt";
        
        public void GuardarLiquidacion(Liquidacion Liquidacion)
        {
            FileStream file = new FileStream(direccionArchivo, FileMode.Append);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine($"{Liquidacion.PersonaLiquidada.Nombre};{Liquidacion.PersonaLiquidada.Documento};{Liquidacion.PersonaLiquidada.Tipo}" +
                $";{Liquidacion.PersonaLiquidada.Sexo};{Liquidacion.PersonaLiquidada.Edad};{Liquidacion.PersonaLiquidada.SemanasCotizadas};" +
                $"{Liquidacion.IBL};{Liquidacion.NumeroLiquidacion}");
            writer.Close();
            file.Close();
        }

        public List<Liquidacion> CosultarTodos()
        {
            List<Liquidacion> Liquidaciones = new List<Liquidacion>();
            FileStream file = new FileStream(direccionArchivo, FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(file);
            string linea = string.Empty;
            while((linea = reader.ReadLine())!= null)
            {
                Liquidaciones.Add(Mapear(linea));
            }
            reader.Close();
            file.Close();
            return Liquidaciones;
        }

        public Liquidacion Mapear(string Linea)
        {
            char delimiter = ';';
            string[] matrizLiquidacion = Linea.Split(delimiter);
            string Nombre, Tipo, Sexo;
            long Documento, NumeroLiquidacion;
            int Edad, SemanasCotizadas;
            double IBL;
            Nombre = matrizLiquidacion[0];
            Documento = long.Parse(matrizLiquidacion[1]);
            Tipo = matrizLiquidacion[2];
            Sexo = matrizLiquidacion[3];
            Edad = int.Parse(matrizLiquidacion[4]);
            SemanasCotizadas = int.Parse(matrizLiquidacion[5]);
            Persona paciente = new Persona(Documento, Nombre, SemanasCotizadas, Tipo, Sexo, Edad);
            NumeroLiquidacion = long.Parse(matrizLiquidacion[7]);
            IBL = double.Parse(matrizLiquidacion[6]);
            if (paciente.Tipo.Equals("Empleado")) return new LiquidacionEmpleado(paciente, IBL, NumeroLiquidacion);
            else return new LiquidacionServidorPublico(paciente, IBL, NumeroLiquidacion);
        }

        public void EliminarLiquidacion(long NumeroLiquidacion)
        {
            List<Liquidacion> Liquidaciones = CosultarTodos();
            FileStream file = new FileStream(direccionArchivo, FileMode.Create);
            file.Close();
            foreach (Liquidacion i in Liquidaciones)
            {
                if (NumeroLiquidacion != i.NumeroLiquidacion)
                {
                    GuardarLiquidacion(i);
                }
            }
        }

        public void ModificarLiquidacion(long NumeroLiquidacion, int SemanasCotizadas)
        {
            List<Liquidacion> Liquidaciones = CosultarTodos();
            FileStream file = new FileStream(direccionArchivo, FileMode.Create);
            file.Close();
            foreach (Liquidacion i in Liquidaciones)
            {
                if (NumeroLiquidacion != i.NumeroLiquidacion)
                {
                    GuardarLiquidacion(i);
                }
                else
                {
                    i.PersonaLiquidada.SemanasCotizadas = SemanasCotizadas;
                }
            }
        }
    }
}
