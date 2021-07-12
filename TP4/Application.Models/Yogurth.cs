using Application.Models.DATOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Yogurth: Lacteo
    {
        public static event MostrarMensaje MostrarMensajeEnPantalla;

        public Yogurth()
        {
            TipoProducto = "Yogurth";
        }

        /// <summary> Tema Base de datos / sql / eventos 
        /// Guardo un lacteo en la base de datos  e invoca un evento para mostrar un mensaje
        /// </summary>
        /// <param name="lacteo">lacteo</param>
        public static void GuardarEnDB(object lacteo)
        {
            if (LacteoDAO.Save((Yogurth)lacteo))
            {
                Yogurth.MostrarMensajeEnPantalla.Invoke("El yogurth se guardo ok"); ;
            }
        }
        /// <summary> Tema Base de datos / sql / eventos 
        /// Actualiza un lacteo en la base de datos  e invoca un evento para mostrar un mensaje
        /// </summary>
        /// <param name="lacteo">lacteo</param>
        public static void ActualizarDB(object lacteo)
        {
            if (LacteoDAO.Update((Yogurth)lacteo))
            {
                Yogurth.MostrarMensajeEnPantalla.Invoke("El yogurth actualizado ok"); ;
            }
        }

        /// <summary> Tema Base de datos / sql / eventos 
        /// Elimina un lacteo en la base de datos  e invoca un evento para mostrar un mensaje
        /// </summary>
        /// <param name="lacteo">lacteo</param>
        public static void EliminarDB(object lacteo)
        {
            if (LacteoDAO.Delete((Yogurth)lacteo))
            {
                Yogurth.MostrarMensajeEnPantalla.Invoke("El yogurth se elimino ok"); ;
            }
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
