using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public abstract class Liquidacion
    {
        public static double SMV = 980657;
        public Persona PersonaLiquidada { get; set; }
       public double R { get; set; }
       public double S { get; set; }
       public double IBL { get; set; }
       public long NumeroLiquidacion { get; set; }
       public double Incremento { get; set; }
       public double TotalLiquidacion { get; set; }

        public Liquidacion(Persona personaLiquidada, double iBL, long numeroLiquidacion)
        {
            PersonaLiquidada = personaLiquidada;
            IBL = iBL;
            NumeroLiquidacion = numeroLiquidacion;
            CalcularS();
            CalcularR();
            CalcularIncremento();
            CalcularLiquidacion();
        }

        public void CalcularLiquidacion()
        {
            TotalLiquidacion = IBL * (R + Incremento);
            TotalLiquidacion /= 100;
        }
        public abstract void CalcularR();
        public abstract void CalcularIncremento();
        public abstract void CalcularS();
    }
}
