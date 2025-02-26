using MediatR;

namespace Library.Application.Domain.Books.Commands
{
    public record CreateBookCommand(
        string Title,
        string SerialNumber
     ) : IRequest<Guid>;

}
