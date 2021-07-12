using Application.Models.DATOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{

    public class Leche : Lacteo
    {
        public static event MostrarMensaje MostrarMensajeEnPantalla;

        public Leche()
        {
            TipoProducto = "Leche";
        }
        protected override void Enfriar()
        {            
            temperaturaEnfriamiento = 40;
            Enfriado = true;
        }


        /// <summary> Tema Base de datos / sql / eventos 
        /// Guardo un lacteo en la base de datos  e invoca un evento para mostrar un mensaje
        /// </summary>
        /// <param name="lacteo">lacteo</param>
        public static void GuardarEnDB(object lacteo)
        {
            if(LacteoDAO.Save((Leche)lacteo))
            {
                Leche.MostrarMensajeEnPantalla.Invoke("La leche se guardo ok"); ;
            }
        }


        /// <summary> Tema Base de datos / sql / eventos 
        /// Actualizo un lacteo en la base de datos  e invoca un evento para mostrar un mensaje
        /// </summary>
        /// <param name="lacteo">lacteo</param>
        public static void ActualizarDB(object lacteo)
        {
            if (LacteoDAO.Update((Leche)lacteo))
            {
                Leche.MostrarMensajeEnPantalla.Invoke("La leche se actualizado ok"); ;
            }
        }

        /// <summary> Tema Base de datos / sql / eventos 
        /// Elimino un lacteo en la base de datos  e invoca un evento para mostrar un mensaje
        /// </summary>
        /// <param name="lacteo">lacteo</param>
        public static void EliminarDB(object lacteo)
        {
            if (LacteoDAO.Delete((Leche)lacteo))
            {
                Leche.MostrarMensajeEnPantalla.Invoke("La leche se elimino ok"); ;
            }
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
