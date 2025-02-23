using Library.Core.Domain.Authors.Models;

namespace Library.Core.Domain.Books.Models
{
    public class Book
    {

        private readonly List<BookAuthor> _authors = new();

        public  Guid Id { get; private set; }
        /// <summary>
        /// Назва книги
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Серийный номер в библиотеке
        /// </summary>
        public string SerialNumber { get; set; }


        /// <summary>
        /// Авторы книги
        /// </summary>
        public IReadOnlyCollection<BookAuthor> Authors => _authors.AsReadOnly();

        

        // please leave it as is for Entity Framework. It needs it for materialization of entities.
        // read about it here: https://docs.microsoft.com/en-us/ef/core/modeling/constructors
        private Book()
        {
        }

        internal Book(Author firstAuthor, string title, string serialNumber)
        { 
          Title = title;
          SerialNumber = serialNumber;
          if (firstAuthor != null )
                AddAuthor(firstAuthor);
        }

        /// <summary>
        /// Добавить автора книге
        /// </summary>
        /// <param name="author"></param>
        public void AddAuthor(Author author)
        {
            if (_authors.All(x => x.AuthorId != author.Id))
            {
                var ao = BookAuthor.Create(Id, author.Id);
                _authors.Add(ao);
            }
        }

        /// <summary>
        /// Добавить книге несколько авторов
        /// </summary>
        /// <param name="authors"></param>
        public void AddAuthor(Author[] authors)
        {
            var bookAuthors = authors
                .Where(o => _authors.All(x => x.AuthorId != o.Id))
                .Select(author => BookAuthor.Create(Id, author.Id));
            _authors.AddRange(bookAuthors);
        }

    }
}
