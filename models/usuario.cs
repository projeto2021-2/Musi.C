namespace musiC.Models
{
    public class Usuario{

        public int Id {get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public Amigos amigos { get; set; }
    }
}