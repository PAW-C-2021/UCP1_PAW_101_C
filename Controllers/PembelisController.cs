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
    public class PembelisController : Controller
    {
        private readonly PemesananMakananContext _context;

        public PembelisController(PemesananMakananContext context)
        {
            _context = context;
        }

        // GET: Pembelis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pembelis.ToListAsync());
        }

        // GET: Pembelis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pembeli = await _context.Pembelis
                .FirstOrDefaultAsync(m => m.IdCustumer == id);
            if (pembeli == null)
            {
                return NotFound();
            }

            return View(pembeli);
        }

        // GET: Pembelis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pembelis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCustumer,Telpon,Alamat,Email,PasswordCustumer,Nama")] Pembeli pembeli)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pembeli);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pembeli);
        }

        // GET: Pembelis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pembeli = await _context.Pembelis.FindAsync(id);
            if (pembeli == null)
            {
                return NotFound();
            }
            return View(pembeli);
        }

        // POST: Pembelis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCustumer,Telpon,Alamat,Email,PasswordCustumer,Nama")] Pembeli pembeli)
        {
            if (id != pembeli.IdCustumer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pembeli);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PembeliExists(pembeli.IdCustumer))
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
            return View(pembeli);
        }

        // GET: Pembelis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pembeli = await _context.Pembelis
                .FirstOrDefaultAsync(m => m.IdCustumer == id);
            if (pembeli == null)
            {
                return NotFound();
            }

            return View(pembeli);
        }

        // POST: Pembelis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pembeli = await _context.Pembelis.FindAsync(id);
            _context.Pembelis.Remove(pembeli);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PembeliExists(int id)
        {
            return _context.Pembelis.Any(e => e.IdCustumer == id);
        }
    }
}
