﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Core.Common;
using Library.Core.Domain.Books.Data;
using Library.Core.Domain.Books.Models;

namespace Library.Core.Domain.Authors.Models
{
    public class Author :Entity
    {
        private readonly List<BookAuthor> _books = new();

        public Guid Id { get; set; } 
        public string Name { get; set; }

        private Author()
        {
        }

        public IReadOnlyCollection<BookAuthor> Books => _books.AsReadOnly();
        internal Author(Guid authorId, string name)
        {
            Id = authorId;
            Name = name;
        }

        public static Author Create(CreateAuthorData data)
        {
            //Validate(new CreateAnimalDataValidator(), data);

            return new Author()
            {
                Id = Guid.NewGuid(),
                Name = data.Name
            };
        }
        /// <summary>
        /// Добавить автора книге
        /// </summary>
        /// <param name="book"></param>
        public void AddBook(Book book)
        {
            if (_books.All(x => x.AuthorId != book.Id))
            {
                var ao = BookAuthor.Create(book.Id, Id );
                _books.Add(ao);
            }
        }

        public void Update(UpdateAuthorData data)
        {
            Name = data.Name;
        }
    }
}
