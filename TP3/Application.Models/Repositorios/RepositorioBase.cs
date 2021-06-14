using Application.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Repositorios
{
    public abstract class RepositorioBase<T> : IRepositorio<T>
    {
        public abstract void Create(T entity);
        public abstract List<T> GetAll();
        public abstract T GetById(long entityId);
        public abstract void Remove(T entity);
        public abstract void Update(T entity);
    }
}
