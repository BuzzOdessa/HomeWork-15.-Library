using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Domain.Authors.Queries
{
    public record AuthorDto
    (
         Guid Id ,
         string Name 
    );
}
