using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Application.Domain.Books.Commands;
using Library.Core.Common;
using Library.Core.Domain.Authors;
using Library.Core.Domain.Authors.Common;
using Library.Core.Domain.Books.Common;
using Library.Core.Domain.Books.Data;
using MediatR;

namespace Library.Application.Domain.Authors.Commands
{
    

    internal class UpdateAuthorCommandHandler(
       IAuthorRepository authorsRepository,
       IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdateAuthorCommand>
    {
        public async Task Handle(
            UpdateAuthorCommand command,
            CancellationToken cancellationToken)
        {
            var author = await authorsRepository.GetById(command.Id, cancellationToken);
            var data = new UpdateAuthorData(command.Name);
            author.Update(data);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
