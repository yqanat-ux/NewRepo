using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Favbook.Data;
using Favbook.Models;

namespace Favbook.Controllers
{
    public class boatbuysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public boatbuysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: boatbuys
        public async Task<IActionResult> Index()
        {
            return View(await _context.boatbuy.ToListAsync());
        }

        // GET: boatbuys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boatbuy = await _context.boatbuy
                .FirstOrDefaultAsync(m => m.id == id);
            if (boatbuy == null)
            {
                return NotFound();
            }

            return View(boatbuy);
        }
        public async Task<IActionResult> SearchForm()
        {
            return View();
        }
        // GET: boatbuys/Create

        public string ShowSearchFormResult(String SearchBook)
        {
            return "The data you submit is " + SearchBook;
        }
        public IActionResult Create()
        {
            return View();
        }
       
        // POST: boatbuys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MyProperty,id,rentername,RENTEDrname,boattype,renttime,describtion,url")] boatbuy boatbuy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boatbuy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(boatbuy);
        }

        // GET: boatbuys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boatbuy = await _context.boatbuy.FindAsync(id);
            if (boatbuy == null)
            {
                return NotFound();
            }
            return View(boatbuy);
        }

        // POST: boatbuys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MyProperty,id,rentername,RENTEDrname,boattype,renttime,describtion,url")] boatbuy boatbuy)
        {
            if (id != boatbuy.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boatbuy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!boatbuyExists(boatbuy.id))
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
            return View(boatbuy);
        }

        // GET: boatbuys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boatbuy = await _context.boatbuy
                .FirstOrDefaultAsync(m => m.id == id);
            if (boatbuy == null)
            {
                return NotFound();
            }

            return View(boatbuy);
        }

        // POST: boatbuys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boatbuy = await _context.boatbuy.FindAsync(id);
            if (boatbuy != null)
            {
                _context.boatbuy.Remove(boatbuy);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool boatbuyExists(int id)
        {
            return _context.boatbuy.Any(e => e.id == id);
        }
    }
}
