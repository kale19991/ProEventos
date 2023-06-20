using System.Threading.Tasks;
using ProEventos.Persistence.Contexts;
using ProEventos.Persistence.Interfaces;
using ProEventos.Domain.Entities;
using System;

namespace ProEventos.Persistence
{
    public class Persistence<TEntity, TKey> : IPersistence<TEntity, TKey> 
    where TEntity  : Entity<TKey>
    where TKey : IComparable
    {
        protected readonly DataContext _context;
        public Persistence(DataContext context)
        {
            _context = context;
        }
        public void Add(TEntity entity)
        {
            _context.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }
        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        public void DeleteRange(TEntity[] entitys)
        {
            _context.RemoveRange(entitys);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }       

    }
}