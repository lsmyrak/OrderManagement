using API.Repositories;
using AutoMapper;
using Contracts.Dtos;
using Domain.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Commands
{
    public class AddArticleCommand : IRequest<int>
    {
        public ArticleDto model { get; set; }

        public AddArticleCommand(ArticleDto model)
        {
            this.model = model;
        }
    }

    public class AddArticleCommandHandler : IRequestHandler<AddArticleCommand, int>
    {
        private readonly IRepository<Article> _articleRepository;
        private readonly IMapper _mapper;
        public AddArticleCommandHandler(IRepository<Article> articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddArticleCommand request, CancellationToken cancellationToken)
        {
            ArticleDto model = request.model;
            if (model == null)
            {
                return 1;
            }
            await _articleRepository.Insert(_mapper.Map<Article>(model), cancellationToken);
            return 0;
        }
    }
}
