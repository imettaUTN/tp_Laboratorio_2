using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Repositorios
{

    public class RepositorioLacteos : RepositorioBase<Lacteo>
    {
        private static List<Lacteo> lacteos = new List<Lacteo>();

        public override void Create(Lacteo entity)
        {
            lacteos.Add(entity);
        }

        public override List<Lacteo> GetAll()
        {
            return lacteos;
        }

        public override Lacteo GetById(long entityId)
        {
            foreach (Lacteo l in lacteos)
            {
                if (l.ID == entityId)
                {
                    return l;
                }
            }
            return null;
        }

        public override void Remove(Lacteo entity)
        {
            lacteos.Remove(entity);
        }

        public override void Update(Lacteo entity)
        {
            int index = 0;
            foreach (Lacteo ad in lacteos)
            {
                if (ad.ID == entity.ID)
                {
                    break;
                }
                index++;
            }
            lacteos.RemoveAt(index);
            lacteos.Add(entity);

        }
    }
}
