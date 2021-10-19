using System;
using System.Collections.Generic;

namespace musiC.Models
{
    public class Playlist{
        
        public int Id {get; set; }
        public string nome { get; set; }
        public DateTime criadoEm { get; set; }
        public List<Musica> musicas;
    }
}