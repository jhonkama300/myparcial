using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Policy;
using System.Runtime.CompilerServices;
using System.ComponentModel.Design;
using Microsoft.SqlServer.Server;
using Entity;
using BLL;

namespace Presentacion
{
    public class Program
    {
        public static void Main()
        {
            new Administrar();
        }
    }

    class Administrar
    {
        public Administrar()
        {
            Opciones(Menu());
        }

        public int Menu()
        {
            Console.Clear();
            Console.WriteLine("opciones");
            Console.WriteLine("guardar     (1)");
            Console.WriteLine("buscar      (2)");
            Console.WriteLine("modificar   (3)");
            Console.WriteLine("eliminar    (4)\n");
            Console.WriteLine("salir       (0)\n");
            return (int)ValidarNumero(">>> ");
        }

        public void Opciones(int Opcion)
        {
            switch (Opcion)
            {
                case 0: {  break; }
                case 1: { ValidarGuardado(); Console.ReadKey(); break; }
                case 2: { break; }
                case 3: { break; }
                case 4: { break; }
                default: { break; }

            }
        }

        public Persona DatosPersona()
        {
            string Nombre, Sexo, Tipo;
            long Cedula;
            int SemanasCotizadad,Edad;
            
            Console.Write("Nombre: "); Nombre = Console.ReadLine();
            Cedula = (long)ValidarNumero("Documento: ");
            Edad = (int)ValidarNumero("Edad: ");
            Console.Write("sexo M/F: "); Sexo = Console.ReadLine();
            Sexo = Sexo.ToUpper();
            Console.Write("Tipo E/S: "); Tipo = Console.ReadLine();
            Tipo = Tipo.ToUpper();
            if (Tipo.Equals("E")) Tipo = "Empleado";
            else Tipo = "Servidor publico";
            SemanasCotizadad = (int)ValidarNumero("Semanas cotizadas: ");
            if (SemanasCotizadad >= 1300)
            {
                return new Persona(Cedula, Nombre, SemanasCotizadad, Tipo, Sexo, Edad);
            }
            else return null;
        }

        public Liquidacion DatosLiquidacion()
        {
            Persona personaLiquidada = DatosPersona();
            double IBL; long NumeroLiquidacion;
            IBL = ValidarNumero("IBL: ");
            NumeroLiquidacion = (long)ValidarNumero("Numero de liquidacion: ");
            if(personaLiquidada != null)
            {
                if (personaLiquidada.Tipo.Equals("Empleado")) return new LiquidacionEmpleado(personaLiquidada, IBL, NumeroLiquidacion);
                else return new LiquidacionServidorPublico(personaLiquidada, IBL, NumeroLiquidacion);
            }
            else
            {
                Console.WriteLine("El numero de semanas no es admitido");
                return null;
            }
            
        }

        public void ValidarGuardado()
        {
            Liquidacion liquidacion = DatosLiquidacion();
            if (liquidacion != null)
            {
                new ServiciosLiquidacion().GuardarLiquidacion(liquidacion);
            }
            else Console.WriteLine("La liquidacion no cumple las caracteristicas admitidas");
        }

        public double ValidarNumero(string NombreVariable)
        {
            double variable;
            try
            {
                Console.Write(NombreVariable);
                variable = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("no es un numero");
                variable = ValidarNumero(NombreVariable);
            }
            return variable;
        }
    }
   
}