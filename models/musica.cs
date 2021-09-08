using System;
using System.Collections.Generic;


namespace musiC.Models
{
   public class Musica{
        
        public string nome { get; set; }
        public string genero { get; set; }
        public Artista artista { get; set; }
        
        public DateTime lancamento { get; set; }
    }
}