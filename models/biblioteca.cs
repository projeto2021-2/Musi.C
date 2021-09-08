using System.Collections.Generic;

namespace musiC.Models
{
    public class Biblioteca{

        public int Id {get; set; }
        public List<Playlist> playlists { get; set; }
        public List<Album> albuns { get; set; }

        public Usuario usuario {get; set;}
    }
}