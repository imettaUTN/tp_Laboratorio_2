using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Repositorios
{
    public class RepositorioAditivos : RepositorioBase<AditivoProducto>
    {
        private  List<AditivoProducto> aditivos = new List<AditivoProducto>();

        public override void Create(AditivoProducto entity)
        {
            aditivos.Add(entity);
        }

        public override List<AditivoProducto> GetAll()
        {
            return aditivos;
        }

        public override AditivoProducto GetById(long entityId)
        {
           foreach(AditivoProducto ad in aditivos)
            {
                if(ad.ID == entityId)
                {
                    return ad;
                }
            }
            return null;
        }

        public override void Remove(AditivoProducto entity)
        {
            this.aditivos.Remove(entity);
        }

        public override void Update(AditivoProducto entity)
        {
            int index = 0;
            foreach (AditivoProducto ad in aditivos)
            {
                if (ad.ID == entity.ID)
                {
                    break;
                }
                index++;
            }
            aditivos.RemoveAt(index);
            aditivos.Add(entity);


        }
    }
}
