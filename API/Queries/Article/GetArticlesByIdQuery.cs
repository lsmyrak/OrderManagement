using API.Services;
using Contracts.Dtos;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.Queries.Article
{
    public class GetArticlesByIdQuery:IRequest<ArticleDto>
    {
        public int Id { get; set; }
        public GetArticlesByIdQuery(int id)
        {
            Id = id;
        }
    }
    public class GetArticlesQueryByIdHandler : IRequestHandler<GetArticlesByIdQuery, ArticleDto>
    {
        private IArticleService _articleService;

        public GetArticlesQueryByIdHandler(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<ArticleDto> Handle(GetArticlesByIdQuery request, CancellationToken cancellationToken)
        {
        
            try
            {
                return await _articleService.Get(request.Id,cancellationToken);
            }
            catch
            {
            }
            finally
            { 
            }
            return new ArticleDto(); ;
        }
    }
}
