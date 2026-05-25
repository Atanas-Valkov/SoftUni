using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazorViewsAndLayouts_BookShelf.Data;
using RazorViewsAndLayouts_BookShelf.DbModels;

namespace RazorViewsAndLayouts_BookShelf.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookShelfDbContext _dbContext;
        public BooksController(BookShelfDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Book> books = _dbContext.Books
                .AsNoTracking()
                .Include(b=>b.Author)
                .OrderBy(b=>b.Title)
                .ThenBy(b=>b.Year)
                .ToList();

            return View(books);
        }

        public IActionResult Create()
        {

            return Ok("ad");
        }
    }
}