namespace musiC.Models
{
    public class Usuario{

        public int Id {get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public Amigos amigos { get; set; }

    }
}