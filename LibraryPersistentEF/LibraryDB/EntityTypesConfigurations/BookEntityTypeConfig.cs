using Library.Core.Domain.Books.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryPersistentEF.LibraryDB.EntityTypesConfigurations
{
    public class BookEntityTypeConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
            .HasMaxLength(220)
            .IsRequired();

            builder.Property(x => x.SerialNumber)
            .HasMaxLength(50)
            .IsRequired();
            builder
                        .Metadata
                        .FindNavigation(nameof(Book.Authors))!
                        .SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.HasMany(x => x.Authors)
                        .WithOne(x => x.Book)
                        .HasForeignKey(x => x.BookId);        }

    }
}
