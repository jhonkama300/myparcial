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
        private static string direccionArchivo = "Repository.txt";
        
        public void GuardarLiquidacion(Liquidacion Liquidacion)
        {
            FileStream file = new FileStream(direccionArchivo, FileMode.Append);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine($"{Liquidacion.PersonaLiquidada.Nombre};{Liquidacion.PersonaLiquidada.Documento};{Liquidacion.PersonaLiquidada.Tipo}" +
                $";{Liquidacion.PersonaLiquidada.Sexo};{Liquidacion.PersonaLiquidada.Edad};{Liquidacion.PersonaLiquidada.SemanasCotizadas};{Liquidacion.Incremento};" +
                $"{Liquidacion.IBL};{Liquidacion.NumeroLiquidacion};{Liquidacion.R};{Liquidacion.S};{Liquidacion.TotalLiquidacion}");
            writer.Close();
            file.Close();
        }

    }
}
