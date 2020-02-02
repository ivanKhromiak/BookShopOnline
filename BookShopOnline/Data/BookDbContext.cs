using BookShopOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShopOnline.Data
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
