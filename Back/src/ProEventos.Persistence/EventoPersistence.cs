using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Entities;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Persistence
{
    public class EventoPersistence : Persistence<Evento>, IEventoPersistence
    {
        public EventoPersistence(DataContext context) : base(context)
        {
        }

        public async Task<Evento[]> GetAllEventsAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lotes)
            .Include(e => e.RedesSociais);

            if (includePalestrantes)
            {
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            return await query.ToArrayAsync();
        }

        public async Task<Evento[]> GetAllEventsByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lotes)
            .Include(e => e.RedesSociais);

            if (includePalestrantes)
            {
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query.Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventsByIdAsync(int id, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lotes)
            .Include(e => e.RedesSociais);

            if (includePalestrantes)
            {
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}