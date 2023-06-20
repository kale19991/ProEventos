using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain.Entities;

namespace ProEventos.Persistence.Interfaces
{
    public interface IPalestrantePersistence : IPersistence<Palestrante, int>
    {
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false);
        Task<Palestrante> GetPalestrantesByIdAsync(int id, bool includeEventos = false);
    }
}