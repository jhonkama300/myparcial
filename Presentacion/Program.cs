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

namespace Presentacion
{
    public class Program
    {
        public static void Main()
        {
            Persona p1 = new Persona(1234,"jhon", 1450, "Empleado", "M", 68);
            Liquidacion liquiadacion = new LiquidacionEmpleado(p1,980657.00,1);
            Console.WriteLine("S = {0}", liquiadacion.S);
            Console.WriteLine("R = {0}", liquiadacion.R);
            Console.WriteLine("R+Incremento = {0}", liquiadacion.R + liquiadacion.Incremento);
            Console.WriteLine("Incremento = {0}", liquiadacion.Incremento);
            Console.WriteLine("Liquidacion = {0}", liquiadacion.TotalLiquidacion);
            Persona p2 = new Persona(1234, "jhon", 1550, "Servidor Publico", "M", 55);
            Liquidacion liquiadacionS = new LiquidacionServidorPublico(p2, 3000003.00, 2);
            Console.WriteLine("S = {0}", liquiadacionS.S);
            Console.WriteLine("R = {0}", liquiadacionS.R);
            Console.WriteLine("R+Incremento = {0}", liquiadacionS.R + liquiadacionS.Incremento);
            Console.WriteLine("Incremento = {0}", liquiadacionS.Incremento);
            Console.WriteLine("Liquidacion = {0}", liquiadacionS.TotalLiquidacion);
            Console.ReadKey();
        }
    }

   
}