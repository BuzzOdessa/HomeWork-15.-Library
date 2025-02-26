using Library.Core.Common;
using Library.Core.Domain.Authors;
using Library.Core.Domain.Authors.Common;
using Library.Core.Domain.Authors.Models;
using MediatR;

namespace Library.Application.Domain.Authors.Commands
{

    internal class CreateAuthorCommandHanlder(
        IAuthorRepository authorsRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<CreateAuthorCommand, Guid>
    {

        public async Task<Guid> Handle(
            CreateAuthorCommand command,
            CancellationToken cancellationToken
        )
        {
            var data = new CreateAuthorData(command.Name);

            var author = Author.Create(data);

            authorsRepository.Add(author);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return author.Id;

        }

    }
}
