using API.Repositories;
using AutoMapper;
using Contracts.Dtos;
using Domain.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Queries
{
    public class GetArticlesByIdQuery : IRequest<ArticleDto>
    {
        public int Id { get; set; }
        public GetArticlesByIdQuery(int id)
        {
            Id = id;
        }
    }
    public class GetArticlesQueryByIdHandler : IRequestHandler<GetArticlesByIdQuery, ArticleDto>
    {
        private readonly IRepository<Article> _articleRepository;
        private readonly IMapper _mapper;

        public GetArticlesQueryByIdHandler(IRepository<Article> articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task<ArticleDto> Handle(GetArticlesByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return _mapper.Map<ArticleDto>(await _articleRepository.Get(request.Id, cancellationToken));
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
