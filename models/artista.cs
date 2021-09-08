using System;
using System.Collections.Generic;

namespace musiC.Models
{
    public class Artista{
        
        public string nome { get; set; }
        public List<string> integrantes { get; set; }
        public List<Album> albuns {get; set;}

    }
}