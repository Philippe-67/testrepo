using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class VocabulairesController : Controller
    {
        private readonly DataDbDicoContext _context;

        public VocabulairesController(DataDbDicoContext context)
        {
            _context = context;
        }

        // GET: Vocabulaires
        public async Task<IActionResult> Index()
        {
              return _context.Vocabulaire != null ? 
                          View(await _context.Vocabulaire.ToListAsync()) :
                          Problem("Entity set 'WebApplication1Context.Vocabulaire'  is null.");
        }

        // GET: Vocabulaires/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vocabulaire == null)
            {
                return NotFound();
            }

            var vocabulaire = await _context.Vocabulaire
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vocabulaire == null)
            {
                return NotFound();
            }

            return View(vocabulaire);
        }

        // GET: Vocabulaires/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vocabulaires/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Mot,Traduction")] Vocabulaire vocabulaire)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vocabulaire);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vocabulaire);
        }

        // GET: Vocabulaires/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vocabulaire == null)
            {
                return NotFound();
            }

            var vocabulaire = await _context.Vocabulaire.FindAsync(id);
            if (vocabulaire == null)
            {
                return NotFound();
            }
            return View(vocabulaire);
        }

        // POST: Vocabulaires/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Mot,Traduction")] Vocabulaire vocabulaire)
        {
            if (id != vocabulaire.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vocabulaire);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VocabulaireExists(vocabulaire.Id))
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
            return View(vocabulaire);
        }

        // GET: Vocabulaires/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vocabulaire == null)
            {
                return NotFound();
            }

            var vocabulaire = await _context.Vocabulaire
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vocabulaire == null)
            {
                return NotFound();
            }

            return View(vocabulaire);
        }

        // POST: Vocabulaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vocabulaire == null)
            {
                return Problem("Entity set 'WebApplication1Context.Vocabulaire'  is null.");
            }
            var vocabulaire = await _context.Vocabulaire.FindAsync(id);
            if (vocabulaire != null)
            {
                _context.Vocabulaire.Remove(vocabulaire);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VocabulaireExists(int id)
        {
          return (_context.Vocabulaire?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
