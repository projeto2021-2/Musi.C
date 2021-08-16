using System;

namespace backEnd
{
    class Musica{
        
        public string nome { get; set; }
        public string genero { get; set; }
        public DateTime lancamento { get; set; }

        public Artista artista { get; set; }
    }
}