using Library.Core.Domain.Books.Models;

namespace Library.Core.Domain.Books.Common
{
    public interface IBookActions
    {
        Task<Book> GetById(Guid id, CancellationToken cancellationToken);
        
        // for the love of whatever higher power you believe in, please don't use Task here.
        // Read the documentation of the EF Core for further reasoning 
        void Add(Book book);

        // for the love of whatever higher power you believe in, please don't use Task here.
        // Read the documentation of the EF Core for further reasoning
        void Delete(Book book);
    }
}
