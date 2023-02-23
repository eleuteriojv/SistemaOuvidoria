using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ouvidoria.Models
{
    public class Setor
    {
        [Key]
        [DisplayName("SetorId")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Precisamos do E-mail")]
        [DisplayName("E-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Precisamos do nome do setor")]
        [DisplayName("Nome do Setor")]
        public string Nome { get; set; }
        public ICollection<Solicitacao> Solicitacoes { get; set; }
    }
}
