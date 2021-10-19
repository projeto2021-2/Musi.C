using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


    namespace musiC.Models
{
        public class Usuario{

            [Key]
            public int UserId {get; set; }
            public string Login { get; set; }
            public string Classe { get; set; }

            [JsonIgnore]
            public string Senha {  get; set; }


            public List<Biblioteca> bibliotecas;
            public List<Musica> favoritas;

        }
}