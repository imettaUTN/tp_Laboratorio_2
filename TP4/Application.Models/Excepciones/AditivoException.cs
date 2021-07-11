using System;

namespace Application.Models.Excepciones
{
    public class AditivoException : Exception
    {
        public AditivoException(string mensaje): base(mensaje + " :" + DateTime.Now.ToString("yyyymmddhhmmss")){  }

    }
}
