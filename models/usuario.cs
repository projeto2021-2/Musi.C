namespace musiC.Models
{
    public class Usuario{
        public string username { get; set; }
        public string email { get; set; }
        public Biblioteca biblioteca { get; set; }

        public Amigos amigos { get; set; }
    }
}