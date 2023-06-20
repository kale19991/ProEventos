using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain.Entities;

namespace ProEventos.Persistence.Interfaces
{
    public interface IEventoPersistence : IPersistence<Evento, int>
    {
        Task<Evento[]> GetAllEventsByTemaAsync(string tema, bool includePalestrantes = false);
        Task<Evento[]> GetAllEventsAsync(bool includePalestrantes = false);
        Task<Evento> GetEventsByIdAsync(int id, bool includePalestrantes = false);
    }
}