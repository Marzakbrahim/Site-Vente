using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vente.Data;
using Vente.Models;

namespace Vente.Controllers
{
    public class PaniersController : Controller
    {
        private readonly VenteContext _context;

        public PaniersController(VenteContext context)
        {
            _context = context;
        }

        // GET: Paniers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Panier.ToListAsync());
            
        }
        

        // GET: Paniers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var panier = await _context.Panier
                .FirstOrDefaultAsync(m => m.Id == id);
            if (panier == null)
            {
                return NotFound();
            }

            return View(panier);
        }

        // GET: Paniers/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create()
        {
            //return View();
            var paniers = await _context.Panier.ToListAsync();
            var articles = await _context.Article.ToListAsync();

            // Create a ViewModel to pass both Paniers and Articles to the view
            var viewModel = new PanierViewModel
            {
                Paniers = paniers,
                Articles = articles
            };

            return View(viewModel);
        }

        // POST: Paniers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // POST: Paniers/AddToPanier
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToPanier(string combobox)
        {
            if (string.IsNullOrEmpty(combobox))
            {
                ModelState.AddModelError("combobox", "You must select a product.");
            }

            var articles = await _context.Article.ToListAsync();

            if (ModelState.IsValid)
            {
                var panier = new Panier
                {
                    // Ajoutez les propriétés nécessaires pour créer un nouveau panier
                    Name = "New Panier", // ou une autre valeur appropriée
                };

                _context.Panier.Add(panier);
                await _context.SaveChangesAsync();

                // Ajoutez l'article sélectionné au panier nouvellement créé
                // var articleId = int.Parse(combobox);
                // var article = await _context.Article.FindAsync(articleId);
                // panier.Articles.Add(article);
                // await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            var viewModel = new PanierViewModel
            {
                Paniers = await _context.Panier.ToListAsync(),
                Articles = articles
            };

            return View("Create", viewModel);
        }

        // GET: Paniers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var panier = await _context.Panier.FindAsync(id);
            if (panier == null)
            {
                return NotFound();
            }
            return View(panier);
        }

        // POST: Paniers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Panier panier)
        {
            if (id != panier.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(panier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PanierExists(panier.Id))
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
            return View(panier);
        }

        // GET: Paniers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var panier = await _context.Panier
                .FirstOrDefaultAsync(m => m.Id == id);
            if (panier == null)
            {
                return NotFound();
            }

            return View(panier);
        }

        // POST: Paniers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var panier = await _context.Panier.FindAsync(id);
            if (panier != null)
            {
                _context.Panier.Remove(panier);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PanierExists(int id)
        {
            return _context.Panier.Any(e => e.Id == id);
        }
    }
}
