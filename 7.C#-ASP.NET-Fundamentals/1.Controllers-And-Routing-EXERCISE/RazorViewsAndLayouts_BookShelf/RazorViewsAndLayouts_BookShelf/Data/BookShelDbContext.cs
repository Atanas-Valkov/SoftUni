namespace RazorViewsAndLayouts_BookShelf.Data
{
    using DbModels;

    using Microsoft.EntityFrameworkCore;

    public class BookShelfDbContext : DbContext
    {
        public BookShelfDbContext(DbContextOptions<BookShelfDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Book> Books { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookShelfDbContext).Assembly);
        }
    }
}