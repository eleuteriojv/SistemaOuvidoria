using Ouvidoria.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Ouvidoria.ViewModels
{
    public class EnviarRespostaViewModel
    {
        [DisplayName("Protocolo")]
        public int SolicitacaoId { get; set; }
        [DisplayName("Nome Completo")]
        public string Nome { get; set; }
        [DisplayName("E-mail")]
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Campus { get; set; }
        [DisplayName("Curso (Opcional)")]
        public string Curso { get; set; }
        public string Assunto { get; set; }
        [DisplayName("Atualizado em")]
        public DateTime Atualizado { get; set; }
        public string Status { get; set; }
        public string Detalhes { get; set; }
        public int SetorId { get; set; }
        public Resposta Resposta { get; set; }
        public Setor Setor { get; set; }
        public TipoSolicitacao TipoSolicitacoes { get; set; }
        public Perfil Perfil { get; set; }
    }
}
