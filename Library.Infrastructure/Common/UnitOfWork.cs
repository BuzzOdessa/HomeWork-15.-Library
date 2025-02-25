using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Common;
using LibraryPersistentEF.LibraryDB;

namespace Library.Infrastructure.Common
{
    internal class UnitOfWork(LibraryDbContext dbContext) : IUnitOfWork
    {
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
