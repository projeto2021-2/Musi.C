using System;
using System.Collections.Generic;

namespace backEnd
{
    class usuarios{
        public string username { get; set; }
        public string email { get; set; }
        public string generoMusical { get; set; }
        public string telefone { get; set; }

        public List<Playlist> Playlists { get; set; }
    }


}
