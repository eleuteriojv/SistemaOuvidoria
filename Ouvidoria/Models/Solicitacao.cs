using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using static Ouvidoria.Models.Polo;
using static Ouvidoria.Models.TipoSolicitacao;

namespace Ouvidoria.Models
{
    public class Solicitacao
    {
        [Key]
        [DisplayName("Protocolo")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Precisamos do assunto")]
        [DisplayName("Assunto")]
        [MaxLength(600)]
        public string Assunto { get; set; }
        [Required(ErrorMessage = "Precisamos do nome completo")]
        [DisplayName("Nome Completo")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Precisamos do e-mail")]
        [DisplayName("E-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Precisamos do detalhes da solicitação")]
        [DisplayName("Detalhes")]
        public string Detalhes { get; set; }
        [Required(ErrorMessage = "Precisamos do número de celular")]
        public string Celular { get; set; }
        [Required(ErrorMessage = "Precisamos do seu perfil na instituição")]
        [DisplayName("Tipo de Perfil")]
        public int PerfilId { get; set; }
        [Required(ErrorMessage = "Precisamos do setor da solicitação")]
        [DisplayName("Setor")]
        public int SetorId { get; set; }
        [Required(ErrorMessage = "Precisamos do campus")]
        [DisplayName("Campus")]
        public int PoloId { get; set; }
        [Required(ErrorMessage = "Precisamos do tipo de solicitação")]
        [DisplayName("Tipos de Solicitação")]
        public int TipoReclamacaoId { get; set; }
        public virtual Perfil Perfil { get; set; }
        
        public virtual Setor Setor { get; set; }
    }
}
