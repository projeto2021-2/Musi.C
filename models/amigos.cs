using System.Collections.Generic;

namespace musiC.Models
{
    public class Amigos{
        
        public int Id {get; set;}
        public int IdUsuario { get; set; }
        public List<Usuario> amigos { get; set; }
    }
}