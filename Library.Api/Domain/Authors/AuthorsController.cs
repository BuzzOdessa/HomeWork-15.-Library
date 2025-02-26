using System.ComponentModel.DataAnnotations;
using Library.Api.Constants;
using Library.Api.Domain.Authors.Requests;
using Library.Application.Domain.Authors.Commands;
using Library.Application.Domain.Authors.Queries;
using Library.Application.Domain.Books.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Domain.Authors
{
    /// <summary>
    /// Інформація по авторам
    /// </summary>
    /// <param name="mediator"></param>
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

        /// <summary>
        /// Добавити автора у загальний список
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AddAuthor(
                    [FromBody][Required] CreateAuthorRequest request,
                    CancellationToken cancellationToken = default)
        {
            var command = new CreateAuthorCommand(
                request.Name
            );
            var id = await mediator.Send(command, cancellationToken);
            return Ok(id);
        }

        /// <summary>
        /// Модифікувати інформацію по автору
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAuthor(
                [FromRoute] Guid id,
                [FromBody][Required] UpdateAuthorRequest request,
                CancellationToken cancellationToken = default)
        {
            var command = new UpdateAuthorCommand(
                id,
                request.Name
                
            );
            await mediator.Send(command, cancellationToken);
            return Ok();
        }

        /// <summary>
        /// Видалити автора
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAuthor(
                [FromRoute] Guid id,
                CancellationToken cancellationToken = default)
        {
            var command = new DeleteAuthorCommand(id);
            await mediator.Send(command, cancellationToken);
            return Ok();
        }
    }
}
