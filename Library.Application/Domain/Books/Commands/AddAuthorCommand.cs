using MediatR;

namespace Library.Application.Domain.Books.Commands
{
    public record AddAuthorCommand(Guid BookId, Guid AuthorId) : IRequest;
}
