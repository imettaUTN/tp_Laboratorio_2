using Application.Models.DATOS;
using Application.Models.Excepciones;
using System.Collections.Generic;
using System.Threading;

namespace Application.Models
{
    public class Yogurth : Lacteo
    {
        public static event MostrarMensaje MostrarMensajeEnPantalla;
        private bool incubadoyMezclado;
        private int informeIncubacionYMezcla;

        public Yogurth()
        {
            TipoProducto = "Yogurth";
        }

        public Yogurth(bool incubadoYMezclado, int informeIncubadoMezclado) : this()
        {
            this.IncubadoyMezclado = incubadoYMezclado;
            this.InformeIncubacionYMezcla = informeIncubadoMezclado;
        }

        public bool IncubadoyMezclado
        {
            get { return this.incubadoyMezclado; }
            set { this.incubadoyMezclado = value; }
        }
        public int InformeIncubacionYMezcla
        {
            get { return this.informeIncubacionYMezcla; }
            set { this.informeIncubacionYMezcla = value; }
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
                Yogurth.MostrarMensajeEnPantalla.Invoke("El yogurth actualizado ok");
            }
        }

        /// <summary> Tema Base de datos / sql / eventos 
        /// Elimina un lacteo en la base de datos  e invoca un evento para mostrar un mensaje
        /// </summary>
        /// <param name="lacteo">lacteo</param>
        public static void EliminarDB(object lacteo)
        {
            if (LacteoDAO.Delete(((Yogurth)lacteo).IdLacteo))
            {
                Yogurth.MostrarMensajeEnPantalla.Invoke("El yogurth se elimino ok"); ;
            }
        }

        /// <summary>
        /// Elimina los informes del lacteo en la db
        /// </summary>
        /// <param name="informes"></param>
        public static void EliminarInformesDB(object informes)
        {
            Dictionary<string, int> inf = (Dictionary<string, int>)informes;

            if (LacteoDAO.DeleteInformes(inf))
            {
                Yogurth.MostrarMensajeEnPantalla.Invoke("Los informes del yogurth se eliminaron correctamente"); ;
            }
        }       

    }
}
