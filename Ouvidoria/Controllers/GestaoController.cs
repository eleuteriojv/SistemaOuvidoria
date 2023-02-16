using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ouvidoria.Data;
using Ouvidoria.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace Ouvidoria.Controllers
{
    public class GestaoController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly OuvidoriaDbContext _context;
        public GestaoController(OuvidoriaDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public IActionResult Index()
        {

            return View(_context.Solicitacoes.AsNoTracking().ToList());
        }
        [HttpGet]
        public IActionResult Cadastro()
        {
            List<TipoSolicitacao> tipoSolicitacao = _context.TipoSolicitacoes.AsNoTracking().ToList();
            List<SelectListItem> selectListTipoSolicitacao = tipoSolicitacao.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Tipo
            }).ToList();

            List<Polo> polos = _context.Polos.AsNoTracking().ToList();
            List<SelectListItem> selectListPolos = polos.Select(y => new SelectListItem
            {
                Value = y.Id.ToString(),
                Text = y.Campus
            }).ToList();

            List<Perfil> perfis = _context.Perfis.AsNoTracking().ToList();
            List<SelectListItem> selectListPerfis = perfis.Select(z => new SelectListItem
            {
                Value = z.Id.ToString(),
                Text = z.TipoPerfil
            }).ToList();

            List<Setor> setores = _context.Setores.AsNoTracking().ToList();
            List<SelectListItem> selectListSetores = setores.Select(w => new SelectListItem
            {
                Value = w.Id.ToString(),
                Text = w.Nome
            }).ToList();

            ViewBag.Perfis = selectListPerfis;
            ViewBag.Polos = selectListPolos;
            ViewBag.TipoSolicitacao = selectListTipoSolicitacao;
            ViewBag.Setores = selectListSetores;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Cadastro(Solicitacao solicitacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(solicitacao);
                await _context.SaveChangesAsync();

                // Enviar e-mail
                var assunto = "UMA NOVA OUVIDORIA";
                var mensagem = $"O contato {solicitacao.Nome} abriu uma ouvidoria com o tipo {solicitacao.TipoReclamacaoId} e o assunto falando de {solicitacao.Assunto}.";
                await EnviarEmail(solicitacao.Setor.Email, assunto, mensagem);

                return RedirectToAction(nameof(Index));
            }
            return View(solicitacao);
        }
        public async Task EnviarEmail(string destinatario, string assunto, string mensagem)
        {
            var smtpServer = _configuration.GetValue<string>("Email:SmtpServer");
            var smtpPort = _configuration.GetValue<int>("Email:SmtpPort");
            var smtpUserName = _configuration.GetValue<string>("Email:UserName");
            var smtpPassword = _configuration.GetValue<string>("Email:Senha");
            var senderEmail = _configuration.GetValue<string>("Email:E-mail");

            using (var smtpClient = new SmtpClient(smtpServer, smtpPort))
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential(smtpUserName, smtpPassword);
                smtpClient.EnableSsl = true;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(senderEmail, "Sistema Ouvidoria UGB"),
                    Subject = assunto,
                    Body = mensagem
                };
                mailMessage.To.Add(destinatario);

                await smtpClient.SendMailAsync(mailMessage);
            }
        }
    }
}
