using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;
using ScreenSound.Shared.Modelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;
public class ScreenSoundContext: DbContext
{
    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Musica> Musicas { get; set; }
    public DbSet<Genero> Generos { get; set; }  

    public ScreenSoundContext(DbContextOptions<ScreenSoundContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Musica>()
            .HasOne(m => m.Artista)
            .WithMany(a => a.Musicas)
            .HasForeignKey(m => m.ArtistaId);

        modelBuilder.Entity<Musica>()
            .HasOne(m => m.Genero)
            .WithMany(a => a.Musicas)
            .HasForeignKey(m => m.GeneroId);
    }

}
