using Microsoft.EntityFrameworkCore;

namespace musiC.Models
{
    public class ProjectContext : DbContext{

        public DbSet<Album> albuns {get; set; }
        public DbSet<Amigos> amigos {get; set; }
        public DbSet<Artista> artistas {get; set; }
        public DbSet<Biblioteca> bibliotecas {get; set; }
        public DbSet<Musica> musicas {get; set; }
        public DbSet<Playlist> playlists {get; set; }
        public DbSet<Usuario> usuarios {get; set; }

        // conexão banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder Builder)
        {
           Builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=musiC;Integrated Security=True");
        }

    }
}