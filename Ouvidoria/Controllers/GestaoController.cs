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
using System.Net;
using System;
using System.Xml.Xsl;
using Ouvidoria.Interfaces;
using Ouvidoria.ViewModels;

namespace Ouvidoria.Controllers
{
    public class GestaoController : Controller
    {
        private readonly OuvidoriaDbContext _context;
        private readonly IEmailService _configEmail;
        public GestaoController(OuvidoriaDbContext context, IEmailService configEmail)
        {
            _context = context;
            _configEmail = configEmail;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.Solicitacoes
                .Include(y => y.Setor)
                .Include(y => y.Perfil)
                .Include(y => y.Polos)
                .Include(y => y.TipoSolicitacoes)
                .Include(y => y.Resposta)
                .AsNoTracking().ToList());
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
                solicitacao.DataCadastro = DateTime.Now;
                solicitacao.Status = "Aberto";
                _context.Add(solicitacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(solicitacao);
        }
        [HttpGet]
        public IActionResult EnviarResposta(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var solicitacao = _context.Solicitacoes
               .Include(y => y.Setor)
               .Include(y => y.Polos)
               .Include(y => y.Perfil)
               .Include(y => y.TipoSolicitacoes)
               .Include(y => y.Resposta)
               .Where(x => x.Id == id).AsNoTracking().FirstOrDefault();

            var enviarResposta = new EnviarRespostaViewModel()
            {
                Assunto = solicitacao.Assunto,
                Campus = solicitacao.Polos.Campus,
                Celular = solicitacao.Celular,
                Curso = solicitacao.Curso,
                Detalhes = solicitacao.Detalhes,
                Email = solicitacao.Email,
                Nome = solicitacao.Nome,
                Perfil = solicitacao.Perfil,
                Setor = solicitacao.Setor,
                TipoSolicitacoes = solicitacao.TipoSolicitacoes,
                SolicitacaoId = solicitacao.Id,
                SetorId = solicitacao.Setor.Id,
                Status = solicitacao.Status,
            };
            ViewBag.NomeSetor = enviarResposta.Setor.Nome;
            ViewBag.EmailSetor = enviarResposta.Setor.Email;
            return View(enviarResposta);
        }
        [HttpPost]
        public async Task<IActionResult> EnviarResposta(EnviarRespostaViewModel enviarResposta)
        {
            if (ModelState.IsValid)
            {
                if (await _configEmail.EnviarEmail(enviarResposta.Email, enviarResposta.Assunto, enviarResposta.Resposta.Mensagem))
                {
                    enviarResposta.Resposta.SolicitacaoId = enviarResposta.SolicitacaoId;
                    enviarResposta.Resposta.Atualizado = DateTime.Now;
                    var solicitacao = _context.Solicitacoes.Where(x => x.Id == enviarResposta.SolicitacaoId).FirstOrDefault();
                    solicitacao.Status = "Finalizado";
                    _context.Solicitacoes.Update(solicitacao);
                    _context.Respostas.Add(enviarResposta.Resposta);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(enviarResposta);
        }
        [HttpGet]
        public IActionResult Remover(int id)
        {
            var solicitacao = _context.Solicitacoes
                .Include(y => y.Setor)
                .Include(y => y.Polos)
                .Include(y => y.Perfil)
                .Include(y => y.TipoSolicitacoes)
                .Where(x => x.Id == id).AsNoTracking().FirstOrDefault();
            return View(solicitacao);
        }
        [HttpPost]
        public async Task<IActionResult> Remover(Solicitacao solicitacao)
        {
            _context.Solicitacoes.Remove(_context.Solicitacoes.Find(solicitacao.Id));
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Detalhes(int id)
        {
            var detalhes = _context.Solicitacoes
                .Include(x => x.Setor)
                .Include(y => y.Polos)
                .Include(z => z.TipoSolicitacoes)
                .Include(w => w.Perfil)
                .Include(t => t.Resposta)
                .Where(x => x.Id == id).AsNoTracking().FirstOrDefault();
            return View(detalhes);
        }
        [HttpGet]
        public IActionResult Resultado(int id)
        {
            return View(_context.Respostas
                .Include(y => y.Solicitacao)
                    .ThenInclude(z => z.Setor)
                .Include(y => y.Solicitacao)
                    .ThenInclude(z => z.Polos)
                .Include(y => y.Solicitacao)
                    .ThenInclude(z => z.TipoSolicitacoes)
                .Where(x => x.Id == id).AsNoTracking().FirstOrDefault());
        }
    }
}
