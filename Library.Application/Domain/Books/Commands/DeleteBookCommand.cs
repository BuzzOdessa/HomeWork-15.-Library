using MediatR;

namespace Library.Application.Domain.Books.Commands
{
    public record DeleteBookCommand(Guid Id) : IRequest;
}
