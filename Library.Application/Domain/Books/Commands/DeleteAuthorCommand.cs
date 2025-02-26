using MediatR;

namespace Library.Application.Domain.Books.Commands
{
    public record DeleteAuthorCommand(Guid Id) : IRequest;

}
