using System.Threading;

namespace Application.Models
{

    public abstract class Informe
    {
        protected Thread hiloInformes;

        public abstract int Grabar();
        public abstract bool Actualizar();
        public abstract bool Eliminar();

        public bool HiloTerminado()
        {
            return this.hiloInformes.IsAlive;
        }

        /// <summary>
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
