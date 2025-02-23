using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Domain.Authors.Models;

namespace Library.Core.Domain.Books.Models
{
    public class BookAuthor
    {
        public Guid BookId { get; private set; }
        public Guid AuthorId { get; private set; }
        public Book Book { get; private set; }
        public Author Author { get; private set; }
        private BookAuthor() { }

        private BookAuthor(Guid bookId, Guid authorId)
        {
            BookId   = bookId;
            AuthorId = authorId;
        }

        public static BookAuthor Create(Guid bookId, Guid authorId)
        {
            return new BookAuthor(bookId, authorId);
        }


    }
}
