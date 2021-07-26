using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Interfaces
{
    public interface IRepositorio<T>
    {
        T GetById(long entityId);

        void Create(T entity);

        void Update(T entity);

        void Remove(T entity);
    }
}
