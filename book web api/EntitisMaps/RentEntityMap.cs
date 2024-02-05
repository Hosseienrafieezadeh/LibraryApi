using book.Entitis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace book.EntitisMaps
{
    public class RentEntityMap : IEntityTypeConfiguration<Rent>
    {
        public void Configure(EntityTypeBuilder<Rent> builder)
        {

            builder.HasKey(r => r.Id);
            builder.Property(r => r.BackBook).IsRequired();

            builder.HasOne(r => r.Book)
                   .WithMany(b => b.Rents)
                   .HasForeignKey(r => r.BookId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.Member)
                   .WithMany(m => m.Rents)
                   .HasForeignKey(r => r.UserId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
