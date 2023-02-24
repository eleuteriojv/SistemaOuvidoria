using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        [DisplayName("Tipo de Perfil*")]
        public int PerfilId { get; set; }
        [Required(ErrorMessage = "Precisamos do setor da solicitação")]
        [DisplayName("Setor")]
        public int SetorId { get; set; }
        [Required(ErrorMessage = "Precisamos do campus")]
        [DisplayName("Campus*")]
        public int PoloId { get; set; }
        [Required(ErrorMessage = "Precisamos do tipo de solicitação")]
        [DisplayName("Tipos de Solicitação")]
        public int TipoSolicitacaoId { get; set; }
        [DisplayName("Curso (Opcional)")]
        public string Curso { get; set; }
        [DisplayName("Data de Cadastro")]
        public DateTime DataCadastro { get; set; }
        [DisplayName("Status")]
        public string Status { get; set; }
        public virtual Perfil Perfil { get; set; }
        
        public virtual Setor Setor { get; set; }
        public virtual Polo Polos { get; set; }
        public virtual TipoSolicitacao TipoSolicitacoes { get; set; }
        public virtual Resposta Resposta { get; set; }
    }
}
