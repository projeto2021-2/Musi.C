using System;


namespace musiC.Models
{
   public class Musica{
        
        public int Id {get; set; }
        public string nome { get; set; }
        public string genero { get; set; }
        public DateTime lancamento { get; set; }
        public Artista artista { get; set; }
    }
}