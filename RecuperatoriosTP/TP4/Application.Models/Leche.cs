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
        /// Elimina un lacteo en la base de datos  e invoca un evento para mostrar un mensaje
        /// </summary>
        /// <param name="lacteo">lacteo</param>
        public static void EliminarDB(object lacteo)
        {
            if (LacteoDAO.Delete(((Leche)lacteo).IdLacteo))
            {
                Leche.MostrarMensajeEnPantalla.Invoke("La leche se elimino ok"); ;
            }
        }
        /// <summary>
        /// Elimina los informes de la db
        /// </summary>
        /// <param name="informes"></param>
        public static void EliminarInformesDB(object informes)
        {
            Dictionary<string, int> inf = (Dictionary<string, int>)informes;

            if (LacteoDAO.DeleteInformes(inf))
            {
            Leche.MostrarMensajeEnPantalla.Invoke("Los informes de la leche se eliminaron correctamente"); ;
            }
        }

    }
}
