using System.Collections.Generic;

namespace musiC.Models
{
    public class Artista{
        
        public int Id {get; set; }
        public string nome { get; set; }
        public List<Integrante> integrantes { get; set; }
    }
}