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
            Console.WriteLine("\tOpciones");
            Console.WriteLine("Guardar     (1)");
            Console.WriteLine("Buscar      (2)");
            Console.WriteLine("Modificar   (3)");
            Console.WriteLine("Eliminar    (4)\n");
            Console.WriteLine("Salir       (0)\n");
            return (int)ValidarNumero(">>> ");
        }

        public void Opciones(int Opcion)
        {
            switch (Opcion)
            {
                case 0: {  break; }
                case 1: { Console.Clear(); ValidarGuardado(); Console.ReadKey(); new Administrar(); break; }
                case 2: { Console.Clear(); ConsultarLiquidaciones(); Console.ReadKey(); new Administrar(); break; }
                case 3: { Console.Clear(); ModificarLiquidacion(); Console.ReadKey(); new Administrar(); break; }
                case 4: { Console.Clear(); EliminarLiquidacion(); Console.ReadKey(); new Administrar(); break; }
                default: { new Administrar(); break; }

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

        public void ConsultarLiquidaciones()
        {
            List<Liquidacion> Liquidaciones = new ServiciosLiquidacion().ConsultarLiquidaciones();
            foreach(Liquidacion i in Liquidaciones)
            {
                MostrarLiquidacion(i);
                Console.WriteLine();
            }
        }

        public void MostrarLiquidacion(Liquidacion liquidacion) {
            Console.WriteLine("Numero de liquidacion: {0}", liquidacion.NumeroLiquidacion);
            Console.WriteLine("Nombre: {0}", liquidacion.PersonaLiquidada.Nombre);
            Console.WriteLine("Documento: {0}", liquidacion.PersonaLiquidada.Documento);
            Console.WriteLine("Edad: {0}", liquidacion.PersonaLiquidada.Edad);
            Console.WriteLine("Sexo: {0}", liquidacion.PersonaLiquidada.Sexo);
            Console.WriteLine("Tipo: {0}", liquidacion.PersonaLiquidada.Tipo);
            Console.WriteLine("Semanas cotizadas: {0}", liquidacion.PersonaLiquidada.SemanasCotizadas);
            Console.WriteLine("IBL: {0}", liquidacion.IBL);
            Console.WriteLine("R: {0}", liquidacion.R);
            Console.WriteLine("Incremento: {0}", liquidacion.Incremento);
            Console.WriteLine("Liquidacion: {0}", liquidacion.TotalLiquidacion);
            Console.WriteLine("Aplica: {0}", liquidacion.Aplica());
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

        public void EliminarLiquidacion()
        {
            ConsultarLiquidaciones();
            Console.WriteLine();
            long NumeroLiquidacion = (long)ValidarNumero("Numero de liquidacion: ");
            new ServiciosLiquidacion().EliminarLiquidacion(NumeroLiquidacion);
        }


        public void ModificarLiquidacion()
        {
            ConsultarLiquidaciones();
            Console.WriteLine();
            long NumeroLiquidacion = (long)ValidarNumero("Numero de liquidacion: ");
            int SemanasCotizadas = (int)ValidarNumero("Semanas Cotizadas: ");
            List<Liquidacion> liquidacions = new ServiciosLiquidacion().ConsultarLiquidaciones();
            foreach(Liquidacion i in liquidacions)
            {
                if(NumeroLiquidacion == i.NumeroLiquidacion)
                {
                    i.PersonaLiquidada.SemanasCotizadas = SemanasCotizadas;
                    i.CalcularS();
                    i.CalcularR();
                    i.CalcularIncremento();
                    i.CalcularLiquidacion();
                    MostrarLiquidacion(i);
                    new ServiciosLiquidacion().EliminarLiquidacion(NumeroLiquidacion);
                    new ServiciosLiquidacion().GuardarLiquidacion(i);
                }
            }
        }
    }
   
}