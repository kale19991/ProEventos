using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Application.Interfaces
{
    public interface IService<TEntity, TKey> 
    where TEntity : class
    where TKey : IComparable 
    {
        //Geral
        Task<BaseResult<TEntity>> Add(TEntity entity);
        Task<BaseResult<TEntity>> Update(TKey id, TEntity entity);
        Task<BaseResult<TEntity>> Delete(TKey id);
    }
}