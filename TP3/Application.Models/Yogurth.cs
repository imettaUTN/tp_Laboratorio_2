using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Yogurth: Lacteo
    {
        public Yogurth()
        {
            TipoProducto = "Yogurth";
        }

        protected override void Enfriar()
        {
            temperaturaEnfriamiento = 65;
            Enfriado = true;
        }

        protected override void Estandarizar()
        {
            //Agrego aditivos que se mezclan previo a la estandarizacion (ya vienen por parametro)
            // setteo parametros utilizados en fabrica para estandarizar la leche
            tiempoEstandarizacion = 0.15;
            temperaturaEstandarizacion = 60;
            porcentajeDeSolidos = 5;
            porcentajeTenorGraso = 3;
            Estandarizado = true;
        }

        protected override void Pasteurizar(int IdOlla, string metodo)
        {
            IdOllaPasteurizacion = IdOlla;
            MetodoPasteurizacion = metodo;
            if (metodo.Equals("Baja temperatura"))
            {
                tiempoPasteurizacion = 63;
                temperaturaPasteurizacion = 30;
            }
            else
            {
                tiempoPasteurizacion = 75;
                temperaturaPasteurizacion = 0.15;
            }
          
            Pasteurizado = true;
        }

    }
}
