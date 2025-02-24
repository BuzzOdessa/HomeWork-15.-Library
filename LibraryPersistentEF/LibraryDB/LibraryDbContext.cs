using Library.Core.Domain.Authors.Models;
using Library.Core.Domain.Books.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryPersistentEF.LibraryDB
{
    public class LibraryDbContext(DbContextOptions<LibraryDbContext> options) : DbContext(options)
    {
        public static string LibraryDbSchema = "library";
        public static string LibraryMigrationHistory = "__LibraryMigrationHistory";

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(LibraryDbSchema);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryDbContext).Assembly);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // todo: do it only for local development
            optionsBuilder.LogTo(Console.WriteLine);
        }
    }
}
