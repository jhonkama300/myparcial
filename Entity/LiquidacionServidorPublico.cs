using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class LiquidacionServidorPublico : Liquidacion
    {
        public LiquidacionServidorPublico(Persona PersonaLiquidada, double iBL, long numeroLiquidacion) : base(PersonaLiquidada, iBL, numeroLiquidacion)
        {
        }

        public override void CalcularIncremento()
        {
            double aux = PersonaLiquidada.SemanasCotizadas - 1300;
            aux /= 50;
            Incremento = Math.Floor(aux) * 1.5;
        }

        public override void CalcularR()
        {
            R = 79 + Incremento;
        }
        public override void CalcularS()
        {
            S = IBL / SMV;
        }
    }
}
