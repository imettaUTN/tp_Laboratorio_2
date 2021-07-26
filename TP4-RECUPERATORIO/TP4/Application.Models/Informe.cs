using System.Threading;

namespace Application.Models
{

    public abstract class Informe
    {
        //Hilo responzable de generar informes
        protected Thread hiloInformes;

        /// <summary>
        /// Guarda un informe en la db
        /// </summary>
        /// <returns></returns>
        public abstract int Grabar();

        /// <summary>
        /// Actualiza un informe en la db
        /// </summary>
        /// <returns></returns>
        public abstract bool Actualizar();

        /// <summary>
        /// Elimina un informe de la db
        /// </summary>
        /// <returns></returns>
        public abstract bool Eliminar();

        /// <summary>
        /// Indica si un hilo esta activo o no
        /// </summary>
        /// <returns></returns>
        public bool HiloTerminado()
        {
            return this.hiloInformes.IsAlive;
        }

        /// <summary> tema threads
        /// cierra los hilos si es que estan abiertos 
        /// </summary>
        public void CerrarHilos()
        {
            if (this.hiloInformes != null && this.hiloInformes.IsAlive)
            {
                this.hiloInformes.Abort();
            }
        }
    }
}
