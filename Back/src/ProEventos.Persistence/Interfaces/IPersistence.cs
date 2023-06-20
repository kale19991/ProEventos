using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain.Entities;
using System;

namespace ProEventos.Persistence.Interfaces
{
    public interface IPersistence<TEntity, TKey> 
    where TEntity : Entity<TKey>
    where TKey : IComparable
    {
        //Geral
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void DeleteRange(TEntity[] entitys);
        Task<bool> SaveChangesAsync();
    }
}