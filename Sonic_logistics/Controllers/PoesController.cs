using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sonic_logistics.Repository;
using Sonic_logistics.Repository.Models;

namespace Sonic_logistics.Controllers
{
    public class PoesController : Controller
    {
        private readonly soniclogisticsDbContext _context;

        public PoesController(soniclogisticsDbContext context)
        {
            _context = context;
        }

        // GET: Poes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pos.ToListAsync());
        }

        // GET: Poes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var po = await _context.Pos
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (po == null)
            {
                return NotFound();
            }

            return View(po);
        }

        // GET: Poes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Poes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CusId,OrderId,SupId,ProdId,OrderDateTime,ShippedDate,Address,City,Country,Status,UserId")] Po po)
        {
            if (ModelState.IsValid)
            {
                _context.Add(po);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(po);
        }

        // GET: Poes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var po = await _context.Pos.FindAsync(id);
            if (po == null)
            {
                return NotFound();
            }
            return View(po);
        }

        // POST: Poes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CusId,OrderId,SupId,ProdId,OrderDateTime,ShippedDate,Address,City,Country,Status,UserId")] Po po)
        {
            if (id != po.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(po);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoExists(po.OrderId))
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
            return View(po);
        }

        // GET: Poes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var po = await _context.Pos
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (po == null)
            {
                return NotFound();
            }

            return View(po);
        }

        // POST: Poes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var po = await _context.Pos.FindAsync(id);
            if (po != null)
            {
                _context.Pos.Remove(po);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoExists(int id)
        {
            return _context.Pos.Any(e => e.OrderId == id);
        }
    }
}
