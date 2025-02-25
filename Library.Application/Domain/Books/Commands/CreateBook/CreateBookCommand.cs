using MediatR;

namespace Library.Application.Domain.Books.Commands.CreateBook
{
    public record CreateBookCommand(
        string Title,
        string SerialNumber
     ) : IRequest<Guid>;
    
}
