using EblaLibraryManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EblaLibraryManager.Data.Configurations
{
    public class LendingConfiguration : IEntityTypeConfiguration<Lending>
    {
        public void Configure(EntityTypeBuilder<Lending> builder)
        {
            builder.ToTable("Lending");

            builder.Property(e => e.Created).HasColumnType("date");

            builder.Property(e => e.Expiration).HasColumnType("date");

            builder.Property(e => e.Returned).HasColumnType("date");

            builder.HasOne(d => d.Book)
                .WithMany(p => p.Lendings)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lending_Book");
        }
    }
}
