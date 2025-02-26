using Library.Core.Common;
using Library.Core.Domain.Books.Common;
using Library.Core.Domain.Books.Data;
using Library.Core.Domain.Books.Models;
using MediatR;

namespace Library.Application.Domain.Books.Commands
{

    internal class CreateBookCommandHanlder(
        IBookRepository booksRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<CreateBookCommand, Guid>
    {

        public async Task<Guid> Handle(
            CreateBookCommand command,
            CancellationToken cancellationToken
        )
        {
            var data = new CreateBookData(command.Title, command.SerialNumber);

            var book = Book.Create(data);

            booksRepository.Add(book);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return book.Id;

        }

    }

}
