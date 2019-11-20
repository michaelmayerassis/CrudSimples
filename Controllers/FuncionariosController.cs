using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prova.Models;

namespace Prova.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly FuncionarioContext _context;
        private readonly DepartamentoContext _context1;

        public FuncionariosController(FuncionarioContext context, DepartamentoContext context1)
        {
            _context = context;
            _context1 = context1;
        }

        // GET: Funcionarios
        public IActionResult Index()
        {
            var funcionarioContext = _context.Funcionarios.Include(f => f.Departamento);
            List<Funcionario> funcionarios = new List<Funcionario>();
            foreach (Funcionario item in funcionarioContext)
            {
                if (item.Fg_Ativo != 0)
                {
                    funcionarios.Add(item);
                }
            }
            return View(funcionarios);
        }

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios
                .Include(f => f.Departamento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // GET: Funcionarios/Create
        public IActionResult Create()
        {
            var funcionarioContext = _context1.Departamentos;
            List<Departamento> funcionarios = new List<Departamento>();
            foreach (Departamento item in funcionarioContext)
            {
                if (item.Fg_Ativo == 1)
                {
                    funcionarios.Add(item);
                }
            }

            ViewData["DepartamentoId"] = new SelectList(funcionarios, "Id", "Nome");
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DepartamentoId,Nome,Dt_Nascimento,Salario,Cargo,Fg_Ativo")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                funcionario.Fg_Ativo = 1;
                _context.Add(funcionario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var funcionarioContext = _context1.Departamentos;
            List<Departamento> funcionarios = new List<Departamento>();
            foreach (Departamento item in funcionarioContext)
            {
                if (item.Fg_Ativo == 1)
                {
                    funcionarios.Add(item);
                }
            }
            ViewData["DepartamentoId"] = new SelectList(funcionarios, "Id", "Nome", funcionario.DepartamentoId);
            return View(funcionario);
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }

            var funcionarioContext = _context1.Departamentos;
            List<Departamento> funcionarios = new List<Departamento>();
            foreach (Departamento item in funcionarioContext)
            {
                if (item.Fg_Ativo == 1)
                {
                    funcionarios.Add(item);
                }
            }
            ViewData["DepartamentoId"] = new SelectList(funcionarios, "Id", "Nome", funcionario.DepartamentoId);
            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DepartamentoId,Nome,Dt_Nascimento,Salario,Cargo,Fg_Ativo")] Funcionario funcionario)
        {
            if (id != funcionario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    funcionario.Fg_Ativo = 1;
                    _context.Update(funcionario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionarioExists(funcionario.Id))
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

            var funcionarioContext = _context1.Departamentos;
            List<Departamento> funcionarios = new List<Departamento>();
            foreach (Departamento item in funcionarioContext)
            {
                if (item.Fg_Ativo == 1)
                {
                    funcionarios.Add(item);
                }
            }
            ViewData["DepartamentoId"] = new SelectList(funcionarios, "Id", "Nome", funcionario.DepartamentoId);
            return View(funcionario);
        }

        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios
                .Include(f => f.Departamento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);
            funcionario.Fg_Ativo = 0;
            _context.Funcionarios.Update(funcionario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionarioExists(int id)
        {
            return _context.Funcionarios.Any(e => e.Id == id);
        }
    }
}
