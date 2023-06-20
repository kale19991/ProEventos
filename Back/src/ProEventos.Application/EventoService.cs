using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Extensions.Logging;
using ProEventos.Application.Interfaces;
using ProEventos.Domain;
using ProEventos.Domain.Entities;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Application
{
    public class EventoService : Service<Evento, int>, IEventoService
    {
        private readonly IEventoPersistence _eventoPersistence;
        public EventoService(IEventoPersistence persistence, IValidator<Evento> validator, ILogger<Evento> logger) : base(persistence, validator, logger)
        {
            _eventoPersistence = persistence;
        }
        public override async Task<BaseResult<Evento>> Update(int id, Evento entity)
        {
            try
            {
                var validator = _validator.Validate(entity);
                if (!validator.IsValid)
                    return BaseResult<Evento>.BuildFail(validator, "validação!");

                entity.Id = id;
                _persistence.Update(entity);
                await _persistence.SaveChangesAsync();
                return BaseResult<Evento>.BuildSuccesss(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.Message, exception: ex);
                throw;
            }
        }
        public override async Task<BaseResult<Evento>> Delete(int id)
        {
            try
            {
                var model = await _eventoPersistence.GetEventsByIdAsync(id);
                if (model == null)
                    return BaseResult<Evento>.BuildFail("Objeto n�o encontrado!");

                _persistence.Delete(model);

                if (!await _persistence.SaveChangesAsync())
                    return BaseResult<Evento>.BuildFail("Falha ao tentar deletar!");

                return BaseResult<Evento>.BuildSuccesss(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.Message, exception: ex);
                throw;
            }
        }

        public async Task<BaseResult<Evento[]>> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var model = await _eventoPersistence.GetAllEventsAsync(includePalestrantes);

                return BaseResult<Evento[]>.BuildSuccesss(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.Message, exception: ex);
                throw;
            }
        }

        public async Task<BaseResult<Evento[]>> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var model = await _eventoPersistence.GetAllEventsByTemaAsync(tema, includePalestrantes);

                return BaseResult<Evento[]>.BuildSuccesss(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.Message, exception: ex);
                throw;
            }
        }

        public async Task<BaseResult<Evento>> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var model = await _eventoPersistence.GetEventsByIdAsync(eventoId, includePalestrantes);

                return BaseResult<Evento>.BuildSuccesss(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(message: ex.Message, exception: ex);
                throw;
            }
        }
    }
}