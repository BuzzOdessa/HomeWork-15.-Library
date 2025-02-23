using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Domain.Books.Queries
{
    public record BookDto(
        Guid Id,
        string Title,
        string SerialNumber
    );
    
}
