using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using telefonrehber.Data;
using telefonrehber.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace telefonrehber.Controllers
{
   

    public static class SessionExtensions
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }

    public class kisisController : Controller
    {

        private readonly AppDbContext _context;
         private readonly IHttpContextAccessor _httpContextAccessor;

      
        public kisisController(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;

        }

        // GET: kisis
        public async Task<IActionResult> Index()
        {
            return View(await _context.kisiler.ToListAsync());
        }

 

        // GET: kisis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: kisis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,ad,telefon")] kisi kisi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kisi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kisi);
        }

        // GET: kisis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kisi = await _context.kisiler.FindAsync(id);
            if (kisi == null)
            {
                return NotFound();
            }
            return View(kisi);
        }

        // POST: kisis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,ad,telefon")] kisi kisi)
        {
            if (id != kisi.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kisi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!kisiExists(kisi.id))
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
            return View(kisi);
        }

        // GET: kisis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kisi = await _context.kisiler
                .FirstOrDefaultAsync(m => m.id == id);
            if (kisi == null)
            {
                return NotFound();
            }

            return View(kisi);
        }

        // POST: kisis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kisi = await _context.kisiler.FindAsync(id);
            if (kisi != null)
            {
                _context.kisiler.Remove(kisi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool kisiExists(int id)
        {
            return _context.kisiler.Any(e => e.id == id);
        }
        public IActionResult Search(string searchTerm)
        {
            var kisis = _context.kisiler.Where(k => k.ad.Contains(searchTerm) || k.telefon.Contains(searchTerm));
            return Json(kisis.Select(k => new { ad = k.ad, telefon = k.telefon }));
        }
       
      

    
}
}

