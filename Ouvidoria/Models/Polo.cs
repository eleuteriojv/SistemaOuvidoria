using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ouvidoria.Models
{
    public class Polo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Necessário preencher o campus")]
        public string Campus { get; set; }
        public ICollection<Solicitacao> Solicitacoes { get; set; }
        
    }
}
