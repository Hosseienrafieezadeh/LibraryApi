using book.Entitis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace book.EntitisMaps
{
    public class BooksEntityMaps : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).IsRequired();
            builder.Property(b => b.DateOfRelease).IsRequired();
            builder.Property(b => b.Inventory).IsRequired();

            builder.HasOne(b => b.Writer)
                   .WithMany(w => w.Books)
                   .HasForeignKey(b => b.WriterId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(b => b.Shelf)
                   .WithMany(s => s.Books)
                   .HasForeignKey(b => b.ShelfId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(b => b.Rents)
                   .WithOne(r => r.Book)
                   .HasForeignKey(r => r.BookId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
