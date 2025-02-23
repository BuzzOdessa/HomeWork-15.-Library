using System.ComponentModel.DataAnnotations;
using Library.Api.Constants;
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
    }
}
