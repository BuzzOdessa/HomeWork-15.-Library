using System.ComponentModel.DataAnnotations;
using Library.Api.Constants;
using Library.Api.Domain.Books.Requests;
using Library.Application.Domain.Books.Commands;
using Library.Application.Domain.Books.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Domain.Books
{
    /// <summary>
    /// Інформація по книгам
    /// </summary>
    /// <param name="mediator"></param>
    [Route(Routes.Books)]
    public class BooksController(IMediator mediator) : ControllerBase
    {
        /// <summary>
        /// Отримати список книг
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetBooks(
            [FromQuery][Required] int page = 1,
            [FromQuery][Required] int pageSize = 10,
            CancellationToken cancellationToken = default)
        {
            var query = new GetBooksQuery(page, pageSize);
            var books = await mediator.Send(query, cancellationToken);
            return Ok(books);
        }

        /// <summary>
        /// Створити книгу
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AddBook(
            [FromBody][Required] CreateBookRequest request,
            CancellationToken cancellationToken = default)
        {
            var command = new CreateBookCommand(
                request.Title,
                request.SerialNumber
                );
            var id = await mediator.Send(command, cancellationToken);
            return Ok(id);
        }

        /// <summary>
        /// Модифікувати інформацію по книзі
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBook(
                [FromRoute] Guid id,
                [FromBody][Required] UpdateBookRequest request,
                CancellationToken cancellationToken = default)
        {
            var command = new UpdateBookCommand(
                id,
                request.Title,
                request.SerialNumber
                );
            await mediator.Send(command, cancellationToken);
            return Ok();
        }

        /// <summary>
        /// вказати автора в книзі (якщо вже є, то додастся соавтор)
        /// </summary>
        /// <param name="bookId"> ID  книги</param>
        /// <param name="authorId">ID автора </param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("{bookId}/add-author")]
        public async Task<ActionResult> AddAuthor(
                [FromRoute] Guid bookId,
                [FromBody][Required] Guid authorId,
                CancellationToken cancellationToken = default)
        {
            var command = new AddAuthorCommand(bookId, authorId);
            await mediator.Send(command, cancellationToken);
            return Ok();
        }
        /// <summary>
        /// видалити автора з книги
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="authorId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("{bookId}/remove-author")]
        public async Task<ActionResult> RemoveOwner(
                [FromRoute] Guid bookId,
                [FromBody][Required] Guid authorId,
                CancellationToken cancellationToken = default)
        {
            var command = new RemoveAuthorCommand(bookId, authorId);
            await mediator.Send(command, cancellationToken);
            return Ok();
        }
    }
}
