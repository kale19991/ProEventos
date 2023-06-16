using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain.Entities;

namespace ProEventos.Persistence.Interfaces
{
    public interface IPersistence<TEntity> where TEntity : class
    {
        //Geral
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void DeleteRange(TEntity[] entitys);
        Task<bool> SaveChangesAsync();
    }
}