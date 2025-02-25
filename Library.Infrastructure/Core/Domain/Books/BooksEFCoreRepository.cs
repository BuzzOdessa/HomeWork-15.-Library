using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Domain.Books.Common;
using Library.Core.Domain.Books.Models;
using LibraryPersistentEF.LibraryDB;

namespace Library.Infrastructure.Core.Domain.Books
{
    internal class BooksEFCoreRepository(LibraryDbContext dbContext) : IBookRepository
    {
        public async Task<Book> GetById(Guid id, CancellationToken cancellationToken)
        {
         /*   return await dbContext
                .Animals
                .Include(x => x.Owners)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(cancellationToken) ?? throw new InvalidOperationException("Animal was not found");*/
          return null;
        }

        public void Add(Book book)
        {
            dbContext.Add(book);
        }

        public void Delete(Book book)
        {
            dbContext.Remove(book);
        }
    }
}
