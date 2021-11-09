using System.Collections.Generic;

namespace musiC.Models
{
    public class Biblioteca{

        public int BibliotecaId {get; set; }
        public List<Playlist> playlists { get; set; }
        public List<Album> albuns { get; set; }

    }
}