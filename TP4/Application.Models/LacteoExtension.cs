using Application.Models.DATOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public static class LacteoExtension
    {
        public static string GetDescriptionMateriaPrima(this Lacteo dato)
        {

            return MateriaPrimaDAO.ReadMateriaPrimaById(dato.IdMateriaPrima);
        }
    }
}
