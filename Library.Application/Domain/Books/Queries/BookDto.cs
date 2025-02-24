using Library.Application.Domain.Authors.Queries;
using Library.Core.Domain.Authors.Models;

namespace Library.Application.Domain.Books.Queries
{
    public record BookDto(
        Guid Id,
        string Title,
        string SerialNumber,
        AuthorDto[]?  Authors
    );
    
}
