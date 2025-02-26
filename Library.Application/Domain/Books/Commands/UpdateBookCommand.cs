using MediatR;

namespace Library.Application.Domain.Books.Commands
{
    public record UpdateBookCommand (
          Guid Id,
          string Title,
          string SerialNumber
    ) : IRequest;    
}
