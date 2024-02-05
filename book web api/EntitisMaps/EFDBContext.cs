using book.Entitis;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices.JavaScript;

namespace book.EntitisMaps
{
    public class EFDBContext : DbContext
    {
        public DbSet<Book>  Books { get; set; }
        public DbSet<Member> members { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<Writer> Writers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=tavvbook1;Integrated Security=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFDBContext).Assembly);

        }
    }
}
