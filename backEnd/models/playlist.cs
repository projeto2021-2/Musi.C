using System;
using System.Collections.Generic;

namespace backEnd
{
    class Playlist{
        
        public string nome { get; set; }
        public List<Musica> musicas { get; set; }
        public Usuario usuario { get; set; }
        public DateTime criadoEm { get; set; }
    }
}