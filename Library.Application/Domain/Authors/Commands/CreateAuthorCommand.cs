using MediatR;

namespace Library.Application.Domain.Authors.Commands
{
    public record CreateAuthorCommand(
           string Name
    ) : IRequest<Guid>;
}
