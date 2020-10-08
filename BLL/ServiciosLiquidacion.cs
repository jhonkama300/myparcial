using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace BLL
{
    public class ServiciosLiquidacion
    {
        private Repository repository = new Repository();

        public void GuardarLiquidacion(Liquidacion liquidacion)
        {
            repository.GuardarLiquidacion(liquidacion);
        }

        public List<Liquidacion> ConsultarLiquidaciones()
        {
            return repository.CosultarTodos();
        }
    }
}
