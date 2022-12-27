using API.Services.Interfaces;
using Contracts.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.Queries.Article
{
    public class GetArticlesByFilterQuery:IRequest<IEnumerable<ArticleDto>>
    {
        public string Filter { get; set; }

        public GetArticlesByFilterQuery(string filter)
        {
            Filter = filter;
        }
    }

    public class GetArticlesByFilterQueryHandler : IRequestHandler<GetArticlesByFilterQuery, IEnumerable<ArticleDto>>
    {
        private readonly IArticleService _articleService;
        public GetArticlesByFilterQueryHandler(IArticleService articleService)
        {
            _articleService= articleService;
        }

        public async Task<IEnumerable<ArticleDto>> Handle(GetArticlesByFilterQuery request, CancellationToken cancellationToken)
        {
            return await _articleService.GetByFilter(request.Filter, cancellationToken);
        }
    }

}
