using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pemesanan_Makanan.Models;

namespace Pemesanan_Makanan.Controllers
{
    public class PemiliksController : Controller
    {
        private readonly PemesananMakananContext _context;

        public PemiliksController(PemesananMakananContext context)
        {
            _context = context;
        }

        // GET: Pemiliks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pemiliks.ToListAsync());
        }

        // GET: Pemiliks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pemilik = await _context.Pemiliks
                .FirstOrDefaultAsync(m => m.IdAdmin == id);
            if (pemilik == null)
            {
                return NotFound();
            }

            return View(pemilik);
        }

        // GET: Pemiliks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pemiliks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAdmin,Password,NoTelpon,Email,Nama")] Pemilik pemilik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pemilik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pemilik);
        }

        // GET: Pemiliks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pemilik = await _context.Pemiliks.FindAsync(id);
            if (pemilik == null)
            {
                return NotFound();
            }
            return View(pemilik);
        }

        // POST: Pemiliks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAdmin,Password,NoTelpon,Email,Nama")] Pemilik pemilik)
        {
            if (id != pemilik.IdAdmin)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pemilik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PemilikExists(pemilik.IdAdmin))
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
            return View(pemilik);
        }

        // GET: Pemiliks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pemilik = await _context.Pemiliks
                .FirstOrDefaultAsync(m => m.IdAdmin == id);
            if (pemilik == null)
            {
                return NotFound();
            }

            return View(pemilik);
        }

        // POST: Pemiliks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pemilik = await _context.Pemiliks.FindAsync(id);
            _context.Pemiliks.Remove(pemilik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PemilikExists(int id)
        {
            return _context.Pemiliks.Any(e => e.IdAdmin == id);
        }
    }
}
