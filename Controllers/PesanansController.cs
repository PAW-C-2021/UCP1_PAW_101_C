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
    public class PesanansController : Controller
    {
        private readonly PemesananMakananContext _context;

        public PesanansController(PemesananMakananContext context)
        {
            _context = context;
        }

        // GET: Pesanans
        public async Task<IActionResult> Index()
        {
            var pemesananMakananContext = _context.Pesanans.Include(p => p.IdAdminNavigation).Include(p => p.IdCustumerNavigation).Include(p => p.IdMakananNavigation);
            return View(await pemesananMakananContext.ToListAsync());
        }

        // GET: Pesanans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pesanan = await _context.Pesanans
                .Include(p => p.IdAdminNavigation)
                .Include(p => p.IdCustumerNavigation)
                .Include(p => p.IdMakananNavigation)
                .FirstOrDefaultAsync(m => m.IdPesanan == id);
            if (pesanan == null)
            {
                return NotFound();
            }

            return View(pesanan);
        }

        // GET: Pesanans/Create
        public IActionResult Create()
        {
            ViewData["IdAdmin"] = new SelectList(_context.Pemiliks, "IdAdmin", "Email");
            ViewData["IdCustumer"] = new SelectList(_context.Pembelis, "IdCustumer", "Alamat");
            ViewData["IdMakanan"] = new SelectList(_context.Foods, "IdMakanan", "Keterangan");
            return View();
        }

        // POST: Pesanans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPesanan,NamaMakanan,Harga,Keterangan,Total,IdCustumer,IdAdmin,Tanggal,IdMakanan")] Pesanan pesanan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pesanan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAdmin"] = new SelectList(_context.Pemiliks, "IdAdmin", "Email", pesanan.IdAdmin);
            ViewData["IdCustumer"] = new SelectList(_context.Pembelis, "IdCustumer", "Alamat", pesanan.IdCustumer);
            ViewData["IdMakanan"] = new SelectList(_context.Foods, "IdMakanan", "Keterangan", pesanan.IdMakanan);
            return View(pesanan);
        }

        // GET: Pesanans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pesanan = await _context.Pesanans.FindAsync(id);
            if (pesanan == null)
            {
                return NotFound();
            }
            ViewData["IdAdmin"] = new SelectList(_context.Pemiliks, "IdAdmin", "Email", pesanan.IdAdmin);
            ViewData["IdCustumer"] = new SelectList(_context.Pembelis, "IdCustumer", "Alamat", pesanan.IdCustumer);
            ViewData["IdMakanan"] = new SelectList(_context.Foods, "IdMakanan", "Keterangan", pesanan.IdMakanan);
            return View(pesanan);
        }

        // POST: Pesanans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPesanan,NamaMakanan,Harga,Keterangan,Total,IdCustumer,IdAdmin,Tanggal,IdMakanan")] Pesanan pesanan)
        {
            if (id != pesanan.IdPesanan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pesanan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PesananExists(pesanan.IdPesanan))
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
            ViewData["IdAdmin"] = new SelectList(_context.Pemiliks, "IdAdmin", "Email", pesanan.IdAdmin);
            ViewData["IdCustumer"] = new SelectList(_context.Pembelis, "IdCustumer", "Alamat", pesanan.IdCustumer);
            ViewData["IdMakanan"] = new SelectList(_context.Foods, "IdMakanan", "Keterangan", pesanan.IdMakanan);
            return View(pesanan);
        }

        // GET: Pesanans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pesanan = await _context.Pesanans
                .Include(p => p.IdAdminNavigation)
                .Include(p => p.IdCustumerNavigation)
                .Include(p => p.IdMakananNavigation)
                .FirstOrDefaultAsync(m => m.IdPesanan == id);
            if (pesanan == null)
            {
                return NotFound();
            }

            return View(pesanan);
        }

        // POST: Pesanans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pesanan = await _context.Pesanans.FindAsync(id);
            _context.Pesanans.Remove(pesanan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PesananExists(int id)
        {
            return _context.Pesanans.Any(e => e.IdPesanan == id);
        }
    }
}
