using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Common;
using Library.Core.Domain.Authors.Common;
using Library.Core.Domain.Books.Common;
using MediatR;

namespace Library.Application.Domain.Books.Commands
{

    public class AddAuthorCommandHandler(
        IBookRepository booksRepository,
        IAuthorRepository authorsRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<AddAuthorCommand>
    {
        public async Task Handle(AddAuthorCommand command, CancellationToken cancellationToken)
        {
            var book = await booksRepository.GetById(command.BookId, cancellationToken);
            var author = await authorsRepository.GetById(command.AuthorId, cancellationToken);
            book.AddAuthor(author);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
