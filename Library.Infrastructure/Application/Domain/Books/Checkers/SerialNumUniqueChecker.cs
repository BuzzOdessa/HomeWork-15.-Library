using Library.Core.Domain.Books.Checkers;
using LibraryPersistentEF.LibraryDB;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Application.Domain.Books.Checkers
{

    public class SerialNumUniqueChecker(LibraryDbContext dbContext) : ISerialNumUniqueChecker
    {
        public async Task<bool> IsUnique(string serialNumber, CancellationToken cancellationToken = default)
        {
            return await dbContext.Books.AllAsync(x => x.SerialNumber != serialNumber, cancellationToken);
        }
    }
}
