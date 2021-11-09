using Microsoft.EntityFrameworkCore;
using musiC.Models;

namespace musiC.Data
{
    public class ProjectContext : DbContext{

        public DbSet<Album> Albuns {get; set; }
        public DbSet<Artista> Artistas {get; set; }
        public DbSet<Biblioteca> Bibliotecas {get; set; }
        public DbSet<Musica> Musicas {get; set; }
        public DbSet<Playlist> Playlists {get; set; }
        public DbSet<Usuario> Usuarios {get; set; }


        // conexão banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder Builder)
        {
           Builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=musiC;Integrated Security=True");
        }

        // conexão banco de dados

    }
}