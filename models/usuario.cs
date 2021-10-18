using System.Text.Json.Serialization;


    namespace musiC.Models
{
        public class Usuario{

            public int Id {get; set; }
            public string nome { get; set; }


            public string login { get; set; }

            [JsonIgnore]
            public string Senha {  get; set; }

        }
}