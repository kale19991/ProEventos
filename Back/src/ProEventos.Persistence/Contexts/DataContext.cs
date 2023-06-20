using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain.Entities;

namespace ProEventos.Persistence.Contexts
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
                .HasKey(PE => new {PE.EventoId, PE.PalestranteId});

            modelBuilder.Entity<Evento>()
                .HasMany(e => e.RedesSociais)
                .WithOne(rs => rs.Evento)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Palestrante>()
                .HasMany(e => e.RedesSociais)
                .WithOne(rs => rs.Palestrante)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}