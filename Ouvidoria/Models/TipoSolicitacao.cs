using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ouvidoria.Models
{
    public class TipoSolicitacao
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Precisamos do tipo da solicitação")]
        [DisplayName("Tipo de Reclamação")]
        public string Tipo { get; set; }
        public ICollection<Solicitacao> Solicitacoes { get; set; }
    }
}
