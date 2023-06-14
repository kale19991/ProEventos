using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Entities;

namespace ProEventos.Persistence
{
    public class DataContext : DbContext
    {
        #region DSet
            public DbSet<Evento> Eventos { get; set; }
            public DbSet<Lote> Lotes { get; set; }
            public DbSet<Palestrante> Palestrantes { get; set; }
            public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }
            public DbSet<RedeSocial> RedesSocias { get; set; }
        #endregion
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEvento>()
            .HasKey(pe => new {pe.EventoId, pe.PalestranteId});
        }
    }

}