using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ouvidoria.Models
{
    public class Polo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Precisamos do campus")]
        public string Campus { get; set; }
        public ICollection<Solicitacao> Reclamacoes { get; set; }
    }
}
