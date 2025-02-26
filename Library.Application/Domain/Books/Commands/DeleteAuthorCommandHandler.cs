using Library.Core.Common;
using Library.Core.Domain.Authors.Common;
using MediatR;

namespace Library.Application.Domain.Books.Commands
{
    public class DeleteAuthorCommandHandler(
        IAuthorRepository authorsRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<DeleteAuthorCommand>
    {
        public async Task Handle(
            DeleteAuthorCommand command,
            CancellationToken cancellationToken)
        {
            var author = await authorsRepository.GetById(command.Id, cancellationToken);
            authorsRepository.Delete(author);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }



}
