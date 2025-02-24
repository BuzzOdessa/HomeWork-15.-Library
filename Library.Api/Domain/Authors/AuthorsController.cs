using System.ComponentModel.DataAnnotations;
using Library.Api.Constants;
using Library.Application.Domain.Authors.Queries;
using Library.Application.Domain.Books.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Domain.Authors
{
    [Route(Routes.Authors)]
    public class AuthorsController(IMediator mediator) : ControllerBase
    {
        /// <summary>
        /// Отримати список авторів
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetAuthors(
            [FromQuery][Required] int page = 1,
            [FromQuery][Required] int pageSize = 10,
            CancellationToken cancellationToken = default)
        {
            var query = new GetAuthorsQuery(page, pageSize);
            var authors = await mediator.Send(query, cancellationToken);
            return Ok(authors);
        }
    }
}
