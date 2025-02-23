using Library.Core.Domain.Authors.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _5Layers.Animals.Persistence.EFCore.AnimalsDb.EntityTypesConfigurations
{
    public class AuthorEntityTypeConfig: IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                        .HasMaxLength(220)
                        .IsRequired();

            builder.Metadata
                   .FindNavigation(nameof(Author.Books))!
                   .SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.HasMany(x => x.Books)
                        .WithOne(x => x.Author)
                        .HasForeignKey(x => x.AuthorId);
        }
    }
}
