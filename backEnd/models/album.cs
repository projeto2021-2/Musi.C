using System;
using System.Collections.Generic;

namespace backEnd
{
    class Album{
        public string nome { get; set; }
        public List<Musica> musicas { get; set; }
        public Artista artista { get; set; }
        public DateTime criadoEm { get; set; }
    }
}