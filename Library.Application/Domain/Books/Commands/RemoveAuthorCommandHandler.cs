using Library.Core.Common;
using Library.Core.Domain.Authors.Common;
using Library.Core.Domain.Books.Common;
using MediatR;

namespace Library.Application.Domain.Books.Commands
{

    public class RemoveAuthorCommandHandler(
        IBookRepository booksRepository,
        IAuthorRepository authorsRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<RemoveAuthorCommand>
    {
        public async Task Handle(RemoveAuthorCommand command, CancellationToken cancellationToken)
        {
            var book = await booksRepository.GetById(command.BookId, cancellationToken);
            var author = await authorsRepository.GetById(command.AuthorId, cancellationToken);
            book.RemoveAuthor(author);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
