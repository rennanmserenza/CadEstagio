using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCrudEstagio.Data;
using WebCrudEstagio.Models;

namespace WebCrudEstagio.Controllers
{
    [Authorize]
    public class EstagiariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstagiariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Estagiarios
        public async Task<IActionResult> Index()
        {
            _context.LogAuditoria.Add(
                new LogAuditoria
                {
                    EmailUsuario = User.Identity.Name,
                    DetalhesAuditoria = "Entrou na tela de Listagem de Estagiários."
                });
            _context.SaveChanges();

            return View(await _context.Estagiario.ToListAsync());
        }

        // GET: Estagiarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estagiario = await _context.Estagiario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estagiario == null)
            {
                return NotFound();
            }

            _context.LogAuditoria.Add(
                new LogAuditoria
                {
                    EmailUsuario = User.Identity.Name,
                    DetalhesAuditoria = string.Concat(
                        "Entrou na tela de Detalhes de: ", estagiario.Id,
                        " - ", estagiario.Nome)
                });
            _context.SaveChanges();

            return View(estagiario);
        }

        // GET: Estagiarios/Create
        public IActionResult Create()
        {
            _context.LogAuditoria.Add(
                new LogAuditoria
                {
                    EmailUsuario = User.Identity.Name,
                    DetalhesAuditoria = "Entrou na tela de Login"
                });
            _context.SaveChanges();

            return View();
        }

        // POST: Estagiarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Telefone,CEP,Endereco,Bairro,Cidade,UF,DataAdmissão")] Estagiario estagiario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estagiario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            _context.LogAuditoria.Add(
                new LogAuditoria
                {
                    EmailUsuario = User.Identity.Name,
                    DetalhesAuditoria = string.Concat(
                        "Cadastrou estagiário: ", estagiario.Nome,
                        "Data de admissão: ", DateTime.Now.ToLongDateString())
                });
            _context.SaveChanges();

            return View(estagiario);
        }

        // GET: Estagiarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estagiario = await _context.Estagiario.FindAsync(id);
            if (estagiario == null)
            {
                return NotFound();
            }

            _context.LogAuditoria.Add(
                new LogAuditoria
                {
                    EmailUsuario = User.Identity.Name,
                    DetalhesAuditoria = string.Concat(
                        "Entrou na tela de Edição de: ", estagiario.Id,
                        " - ", estagiario.Nome)
                });
            _context.SaveChanges();

            return View(estagiario);
        }

        // POST: Estagiarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Telefone,CEP,Endereco,Bairro,Cidade,UF,DataAdmissão")] Estagiario estagiario)
        {
            if (id != estagiario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estagiario);
                    await _context.SaveChangesAsync();

                    _context.LogAuditoria.Add(
                    new LogAuditoria
                    {
                        EmailUsuario = User.Identity.Name,
                        DetalhesAuditoria = string.Concat(
                            "Atualizou o estagiário: ", estagiario.Nome,
                            "Data de atualização: ", DateTime.Now.ToLongDateString())
                    });
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstagiarioExists(estagiario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(estagiario);
        }

        // GET: Estagiarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estagiario = await _context.Estagiario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estagiario == null)
            {
                return NotFound();
            }

            _context.LogAuditoria.Add(
                new LogAuditoria
                {
                    EmailUsuario = User.Identity.Name,
                    DetalhesAuditoria = string.Concat(
                        "Entrou na tela de Exclusão de: ", estagiario.Id,
                        " - ", estagiario.Nome)
                });
            _context.SaveChanges();

            return View(estagiario);
        }

        // POST: Estagiarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estagiario = await _context.Estagiario.FindAsync(id);
            _context.Estagiario.Remove(estagiario);
            await _context.SaveChangesAsync();

            _context.LogAuditoria.Add(
                new LogAuditoria
                {
                    EmailUsuario = User.Identity.Name,
                    DetalhesAuditoria = string.Concat(
                        "Deletou o estagiário: ", estagiario.Nome,
                        "Data de exclusão: ", DateTime.Now.ToLongDateString())
                });
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        private bool EstagiarioExists(int id)
        {
            return _context.Estagiario.Any(e => e.Id == id);
        }
    }
}
