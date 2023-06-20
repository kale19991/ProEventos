using System;
using System.Threading.Tasks;
using ProEventos.Domain.Entities;

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