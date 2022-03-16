#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeliveryAPI.Models;
using PedidoAPI.Data;

namespace DeliveryAPI.Controllers
{
    public class Api : Controller
    {
        private readonly AppDbContext _context;

        public Api(AppDbContext context)
        {
            _context = context;
        }

        // GET: Api
        public async Task<IActionResult> orders()
        {
            return View(await _context.Pedidos.ToListAsync());
        }

        // GET: Api/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidos = await _context.Pedidos
                .FirstOrDefaultAsync(m => m.id == id);
            if (pedidos == null)
            {
                return NotFound();
            }

            return View(pedidos);
        }

        // GET: Pedidos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,valor")] Models.Pedidos pedidos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedidos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pedidos);
        }

        // GET: Pedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidos = await _context.Pedidos.FindAsync(id);
            if (pedidos == null)
            {
                return NotFound();
            }
            return View(pedidos);
        }

        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,valor")] Models.Pedidos pedidos)
        {
            if (id != pedidos.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedidos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidosExists(pedidos.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(orders));
            }
            return View(pedidos);
        }

        // GET: Pedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidos = await _context.Pedidos
                .FirstOrDefaultAsync(m => m.id == id);
            if (pedidos == null)
            {
                return NotFound();
            }

            return View(pedidos);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedidos = await _context.Pedidos.FindAsync(id);
            _context.Pedidos.Remove(pedidos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(orders));
        }

        private bool PedidosExists(int id)
        {
            return _context.Pedidos.Any(e => e.id == id);
        }
    }
}
