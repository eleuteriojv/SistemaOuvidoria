using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ouvidoria.Models
{
    public class Resposta
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Necessário preencher o campo de mensagem")]
        [DisplayName("Resposta")]
        public string Mensagem { get; set; }
        public int SolicitacaoId { get; set; }
        public virtual Setor Setor { get; set; }
        public virtual Solicitacao Solicitacao { get; set; }

    }
}
