using Library.Application.Common;
using MediatR;

namespace Library.Application.Domain.Authors.Queries
{
    public record GetAuthorsQuery(int Page, int PageSize) : IRequest<PageResponse<AuthorDto[]>>;    
}
