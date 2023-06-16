using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ProEventos.Application.Interfaces;
using ProEventos.Persistence.Interfaces;
using FluentValidation;
using ProEventos.Domain;

namespace ProEventos.Application
{
    public class Service<TEntity, TKey> : IService<TEntity, TKey> 
    where TEntity : class
    where TKey : IComparable
    {

        protected readonly ILogger<TEntity> _logger;
        protected readonly IPersistence<TEntity> _persistence;
        protected readonly IValidator<TEntity> _validator;
        public Service(IPersistence<TEntity> persistence, IValidator<TEntity> validator, ILogger<TEntity> logger)
        {
            _persistence = persistence;
            _validator = validator;
            _logger = logger;
        }

        public virtual async Task<BaseResult<TEntity>> Add(TEntity entity)
        {
            try
            {
                var validator = _validator.Validate(entity);
                if (!validator.IsValid)
                    return BaseResult<TEntity>.BuildFail(validator, "validação!");

                _persistence.Add(entity);
                await _persistence.SaveChangesAsync();
                return BaseResult<TEntity>.BuildSuccesss(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.Message, exception: ex);
                throw;
            }
        }

        public virtual Task<BaseResult<TEntity>> Update(TKey id, TEntity entity)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.Message, exception: ex);
                throw;
            }
        }

        public virtual Task<BaseResult<TEntity>> Delete(TKey id)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.Message, exception: ex);
                throw;
            }
        }
    }
}