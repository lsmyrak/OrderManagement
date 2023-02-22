using API.Repositories;
using AutoMapper;
using Contracts.Dtos;
using Domain.Model;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Queries
{
    public class GetArticlesByFilterQuery : IRequest<IEnumerable<ArticleDto>>
    {
        public string Filter { get; set; }

        public GetArticlesByFilterQuery(string filter)
        {
            Filter = filter;
        }
    }

    public class GetArticlesByFilterQueryHandler : IRequestHandler<GetArticlesByFilterQuery, IEnumerable<ArticleDto>>
    {
        private readonly IRepository<Article> _articleRepository;
        private readonly IMapper _mapper;
        public GetArticlesByFilterQueryHandler(IRepository<Article> articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ArticleDto>> Handle(GetArticlesByFilterQuery request, CancellationToken cancellationToken)
        {
            var articles = await _articleRepository.GetBy(x => x.Name.Contains(request.Filter)
            || x.NettoPrice.ToString().Contains(request.Filter)
            || x.GrossPrice.ToString().Contains(request.Filter)
            || x.Tax.ToString().Contains(request.Filter), cancellationToken);

            return articles.Select(x => _mapper.Map<ArticleDto>(x));
        }
    }

}
