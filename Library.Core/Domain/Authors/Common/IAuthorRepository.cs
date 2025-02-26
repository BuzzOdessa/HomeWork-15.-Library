using Library.Core.Domain.Authors.Models;

namespace Library.Core.Domain.Authors.Common
{
    public interface IAuthorRepository
    {
        Task<Author> GetById(Guid id, CancellationToken cancellationToken);
        // this method usually is not needed as EF Core tracks changes to entities. Will learn later.
        // Task Update(Author author);

        // for the love of whatever higher power you believe in, please don't use Task here.
        // Read the documentation of the EF Core for further reasoning 
        void Add(Author author);

        // for the love of whatever higher power you believe in, please don't use Task here.
        // Read the documentation of the EF Core for further reasoning
        void Delete(Author author);
    }
}
