using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using ContosoBooks.Models;

namespace ContosoBooks.Controllers
{
    public class AuthorsController : Controller
    {
        private BookContext _context;

        public AuthorsController(BookContext context)
        {
            _context = context;    
        }

        // GET: Authors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Authors.ToListAsync());
        }

        // GET: Authors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Author author = await _context.Authors.SingleAsync(m => m.AuthorID == id);
            if (author == null)
            {
                return HttpNotFound();
            }

            return View(author);
        }

        // GET: Authors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Author author)
        {
            if (ModelState.IsValid)
            {
                _context.Authors.Add(author);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: Authors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Author author = await _context.Authors.SingleAsync(m => m.AuthorID == id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                _context.Update(author);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Author author = await _context.Authors.SingleAsync(m => m.AuthorID == id);
            if (author == null)
            {
                return HttpNotFound();
            }

            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Author author = await _context.Authors.SingleAsync(m => m.AuthorID == id);
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
