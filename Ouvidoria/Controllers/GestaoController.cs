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

namespace Ouvidoria.Controllers
{
    public class GestaoController : Controller
    { 
        private readonly OuvidoriaDbContext _context;
        private readonly IConfigEmail _configEmail;
        public GestaoController(OuvidoriaDbContext context, IConfigEmail configEmail)
        {
            _context = context;
            _configEmail = configEmail;
        }
        public IActionResult Index()
        {
            return View(_context.Solicitacoes
                .Include(y => y.Setor)
                .Include(y => y.Perfil)
                .Include(y => y.Polos)
                .Include(y => y.TipoSolicitacoes)
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
                _context.Add(solicitacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(solicitacao);
        }
        [HttpGet]
        public IActionResult EnviarResposta(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var solicitacao = _context.Solicitacoes
               .Include(y => y.Setor)
               .Include(y => y.Polos)
               .Include(y => y.Perfil)
               .Include(y => y.TipoSolicitacoes)
               .Include(y => y.Resposta)
               .Where(x => x.Id == id).AsNoTracking().FirstOrDefault();
            var resposta = new Resposta()
            {
                SolicitacaoId = solicitacao.Id

            };

            ViewBag.NomeSetor = solicitacao.Setor.Nome;
            ViewBag.EmailSetor = solicitacao.Setor.Email;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EnviarResposta(Resposta resposta)
        {
            if (ModelState.IsValid)
            {
                _context.Respostas.Add(resposta);
                _context.SaveChanges();
            }
            if (await _configEmail.EnviarEmail(resposta.Solicitacao.Email, resposta.Mensagem, resposta.Solicitacao.Detalhes))
            {
                _context.Respostas.Add(resposta);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
            
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
        public async Task<IActionResult> Detalhes(int id)
        {
            var detalhes = _context.Solicitacoes
                .Include(x => x.Setor)
                .Include(y => y.Polos)
                .Include(z => z.TipoSolicitacoes)
                .Include(w => w.Perfil)
                .Where(x => x.Id == id).AsNoTracking().FirstOrDefault();
            return View(detalhes);
        }
    }
}
