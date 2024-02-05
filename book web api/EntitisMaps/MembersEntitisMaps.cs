using book.Entitis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace book.EntitisMaps
{
    public class MembersEntitisMaps : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {

            builder.HasKey(m => m.Id);
            builder.Property(m => m.Name).IsRequired();
            builder.Property(m => m.Email).IsRequired();

            builder.HasMany(m => m.Rents)
                   .WithOne(r => r.Member)
                   .HasForeignKey(r => r.UserId)
                   .OnDelete(DeleteBehavior.NoAction);
        }


    }
}
