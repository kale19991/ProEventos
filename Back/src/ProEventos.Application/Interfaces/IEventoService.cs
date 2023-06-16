using System;
using System.Threading.Tasks;
using ProEventos.Domain;
using ProEventos.Domain.Entities;

namespace ProEventos.Application.Interfaces
{
    public interface IEventoService : IService<Evento, int>
    {
        Task<BaseResult<Evento[]>> GetAllEventosAsync(bool includePalestrantes = false);
        Task<BaseResult<Evento[]>> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<BaseResult<Evento>> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);
    }
}