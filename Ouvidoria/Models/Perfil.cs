using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Ouvidoria.Models
{
    public class Perfil
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Precisamos do seu perfil")]
        [DisplayName("Tipo de Perfil")]
        public string TipoPerfil { get; set; }
        public ICollection<Solicitacao> Solicitacoes { get; set; }
    }
}
