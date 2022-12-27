using API.Services.Interfaces;
using Contracts.Dtos;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.Queries.Article
{
    public class GetArticlesQuery:IRequest<IEnumerable<ArticleDto>>
    {
    }
    public class GetArticlesQueryHandler : IRequestHandler<GetArticlesQuery, IEnumerable<ArticleDto>>
    {
        private IArticleService _articleService;

        public GetArticlesQueryHandler(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<IEnumerable<ArticleDto>> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
        {
         var list = new List<ArticleDto>();
            try
            {
                return await _articleService.GetAll(cancellationToken);
            }
            catch
            {
            }
            finally
            { 
            }
            return list;
        }
    }
}
