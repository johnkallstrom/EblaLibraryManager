using EblaLibraryManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EblaLibraryManager.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");

            builder.Property(e => e.Borrowed).HasColumnType("date");

            builder.Property(e => e.DueDate).HasColumnType("date");

            builder.Property(e => e.Language)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Publisher)
                .HasMaxLength(50);

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(d => d.Author)
                .WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Book_Author");

            builder.HasOne(d => d.AvailabilityStatus)
                .WithMany(p => p.Books)
                .HasForeignKey(d => d.AvailabilityStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Book_AvailabilityStatus");

            builder.HasOne(d => d.Genre)
                .WithMany(p => p.Books)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Book_Genre");
        }
    }
}
