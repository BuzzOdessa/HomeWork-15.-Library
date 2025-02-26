using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Common;
using Library.Core.Domain.Books.Common;
using Library.Core.Domain.Books.Data;
using MediatR;

namespace Library.Application.Domain.Books.Commands
{
     internal class UpdateBookCommandHandler(
        IBookRepository booksRepository,
        IUnitOfWork unitOfWork
     ) : IRequestHandler<UpdateBookCommand>
    {
        public async Task Handle(
            UpdateBookCommand command,
            CancellationToken cancellationToken)
        {
            var book = await booksRepository.GetById(command.Id, cancellationToken);
            var data = new UpdateBookData(command.Title, command.SerialNumber);
            book.Update(data);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
