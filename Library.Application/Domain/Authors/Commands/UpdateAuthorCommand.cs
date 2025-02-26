using MediatR;

namespace Library.Application.Domain.Authors.Commands
{
    public record UpdateAuthorCommand(
              Guid Id,
              string Name
        ) : IRequest;
}
