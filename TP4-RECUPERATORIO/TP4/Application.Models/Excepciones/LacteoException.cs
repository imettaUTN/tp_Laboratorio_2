using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Excepciones
{
    public class LacteoException : Exception
    {
        public LacteoException(string mensaje) : base(mensaje) { }

    }
}
