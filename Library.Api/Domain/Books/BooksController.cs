using System.ComponentModel.DataAnnotations;
using Library.Api.Constants;
using Library.Api.Domain.Books.Requests;
using Library.Application.Domain.Books.Commands.CreateBook;
using Library.Application.Domain.Books.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Domain.Books
{
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

        [HttpPost]
        public async Task<ActionResult> AddAnimal(
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
    }
}
