using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazorViewsAndLayouts_BookShelf.Data;
using RazorViewsAndLayouts_BookShelf.DbModels;

namespace RazorViewsAndLayouts_BookShelf.Controllers
{
    public class AuthorsController: Controller
    {
        private readonly BookShelfDbContext _dbContext;
        public AuthorsController(BookShelfDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Author> authors = _dbContext.Authors
                .AsNoTracking()
                .OrderBy(a => a.Name)
                .ThenBy(a=>a.Country)
                .ToList();

            return View(authors);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Author? author = _dbContext.Authors
                .Include(a => a.Books)
                .AsNoTracking()
                .AsSplitQuery()
                .SingleOrDefault(a => a.Id == id);

            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }
    }
}