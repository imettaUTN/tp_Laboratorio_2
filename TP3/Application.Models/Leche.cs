using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Leche : Lacteo
    {
        public Leche()
        {
            TipoProducto = "Leche";
        }
        protected override void Enfriar()
        {            
            temperaturaEnfriamiento = 40;
            Enfriado = true;
        }

        protected override void Estandarizar()
        {
              //Agrego aditivos que se mezclan previo a la estandarizacion( ya vienen por parametro)
            // setteo parametros utilizados en fabrica para estandarizar la leche
            tiempoEstandarizacion = 0.2;
            temperaturaEstandarizacion = 35;
            porcentajeDeSolidos = 7;
            porcentajeTenorGraso = 2;
            Estandarizado = true;
        }

        protected override void Pasteurizar(int IdOlla, string metodo)
        {
            IdOllaPasteurizacion = IdOlla;
            MetodoPasteurizacion = metodo;
            tiempoPasteurizacion = 30;
            temperaturaPasteurizacion = 80;
            Pasteurizado = true;
        }
    }
}
