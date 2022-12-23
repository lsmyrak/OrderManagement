using API.Commands;
using API.Commands.Article;
using API.Queries.Article;
using API.Queries.Order;
using Contracts.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers.Article
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> AddArticle(ArticleDto articleDto)
        {

            var command = new AddArticleCommand(articleDto);
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateArticle(ArticleDto articleDto)
        {
            var command = new UpdateArticleCommand(articleDto);
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpGet]
        public async Task<IEnumerable<ArticleDto>> Articles()
        {
            return await _mediator.Send(new GetArticlesQuery());
        }
        [HttpGet("{id}")]
        public async Task<ArticleDto> Article(int id)
        {
            return await _mediator.Send(new GetArticlesByIdQuery(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteArticle(int id)
        {
            var command = new DeleteArticleCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
