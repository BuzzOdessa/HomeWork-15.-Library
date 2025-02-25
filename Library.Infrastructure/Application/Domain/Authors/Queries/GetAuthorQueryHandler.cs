using Library.Application.Common;
using Library.Application.Domain.Authors.Queries;
using Library.Application.Domain.Books.Queries;
using LibraryPersistentEF.LibraryDB;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Application.Domain.Authors.Queries
{
    internal class GetAuthorQueryHandler(LibraryDbContext dbContext) : IRequestHandler<GetAuthorsQuery, PageResponse<AuthorDto[]>>
    {
        public async Task<PageResponse<AuthorDto[]>> Handle(
             GetAuthorsQuery query,
        CancellationToken cancellationToken)
        {
            var sqlQuery =
              dbContext.Authors
                       .AsNoTracking()
                       .Include(x => x.Books);
            var skip = query.PageSize * (query.Page - 1);

            var count = sqlQuery.Count();

            var authors = await sqlQuery
                     .OrderBy(a => a.Name)
                     .Skip(skip)
                     .Take(query.PageSize)
                     .Select(x => new AuthorDto(
                         x.Id,
                         x.Name
                        , x.Books.Select(o => new BookDto(o.Book.Id, o.Book.Title , o.Book.SerialNumber,null)).ToArray()
                     //,                         x.Authors.Select(o => new AuthorDto(o.Author.Id, o.Author.Name)).ToArray()
                     ))
                     .ToArrayAsync(cancellationToken);

            return new PageResponse<AuthorDto[]>(count, authors);
        }

    }
    
}
