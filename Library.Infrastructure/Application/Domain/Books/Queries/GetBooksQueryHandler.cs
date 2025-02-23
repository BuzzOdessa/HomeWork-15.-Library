using Library.Application.Common;
using Library.Application.Domain.Books.Queries;
using MediatR;

namespace Library.Infrastructure.Application.Domain.Books.Queries
{
    internal class GetBooksQueryHandler :  IRequestHandler<GetBooksQuery, PageResponse<BookDto[]>>
    {
        public async Task<PageResponse<BookDto[]>> Handle(
        GetBooksQuery query,
        CancellationToken cancellationToken)
        {
            BookDto[] books = null ;
            return new PageResponse<BookDto[]>(0, books);
        }
    }
}
