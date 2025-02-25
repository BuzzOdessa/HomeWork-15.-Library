using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Application.Domain.Books.Queries;

namespace Library.Application.Domain.Authors.Queries
{
    public record AuthorDto
    (
         Guid Id ,
         string Name,
         BookDto[]? Books
    );
}
