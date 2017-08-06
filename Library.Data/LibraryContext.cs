using Microsoft.EntityFrameworkCore;
using Library.Data.Models;

namespace Library.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions options) : base(options) { }
        public DbSet<Patron> Patrons { get; set; }
    }
}
