using Library.Core.Domain.Authors.Common;
using Library.Core.Domain.Authors.Models;
using LibraryPersistentEF.LibraryDB;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Core.Domain.Authors
{

    internal class AuthorsEFCoreRepository(LibraryDbContext dbContext) : IAuthorRepository
    {
        public async Task<Author> GetById(Guid id, CancellationToken cancellationToken)
        {
            return await dbContext
                .Authors
                .Include(x => x.Books)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(cancellationToken) ?? throw new InvalidOperationException("Book was not found");
        }

        public void Add(Author author)
        {
            dbContext.Add(author);
        }

        public void Delete(Author author)
        {
            dbContext.Remove(author);
        }
    }
}
