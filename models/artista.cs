using System.Collections.Generic;

namespace musiC.Models
{
    public class Artista{
        
        public int Id {get; set; }
        public string nome { get; set; }
        public List<Integrantes> integrantes { get; set; }
        public List<Album> albuns {get; set;}
        public List<Musica> musicas {get; set;}

    }
}