using book.Entitis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace book.EntitisMaps
{
    public class ShelfEntityMap: IEntityTypeConfiguration<Shelf>
    {
        public void Configure(EntityTypeBuilder<Shelf> builder)
        {

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Title).IsRequired();

            builder.HasMany(s => s.Books)
                   .WithOne(b => b.Shelf)
                   .HasForeignKey(b => b.ShelfId)
                   .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
