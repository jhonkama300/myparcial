using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class LiquidacionEmpleado : Liquidacion
    {

        public LiquidacionEmpleado(Persona PersonaLiquidada, double iBL, long numeroLiquidacion) : base(PersonaLiquidada, iBL, numeroLiquidacion)
        {
        }

        public override void CalcularR()
        {
            R = 65.5 - 0.5 * S;
        }

        public override void CalcularS()
        {
            S = IBL / SMV;
        }

        public override void CalcularIncremento()
        {
            double aux = PersonaLiquidada.SemanasCotizadas - 1300;
            aux /= 50;
            Incremento = Math.Floor(aux) * 1.5;
        }
    }
}
