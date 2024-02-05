using book.Entitis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace book.EntitisMaps
{
    public class WriterEntityMap: IEntityTypeConfiguration<Writer>
    {
        public void Configure(EntityTypeBuilder<Writer> builder)
        {
            builder.HasKey(w => w.Id);
            builder.Property(w => w.Name).IsRequired();

            builder.HasMany(w => w.Books)
                   .WithOne(b => b.Writer)
                   .HasForeignKey(b => b.WriterId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
