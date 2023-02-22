using API.Repositories;
using AutoMapper;
using Contracts.Dtos;
using Domain.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Commands
{
    public class UpdateArticleCommand : IRequest<int>
    {
        public ArticleDto Model { get; set; }
        public UpdateArticleCommand(ArticleDto model)
        {
            this.Model = model;
        }
    }

    public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand, int>
    {
        private readonly IRepository<Article> _articleRepository;
        private readonly IMapper _mapper;
        public UpdateArticleCommandHandler(IRepository<Article> articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            await _articleRepository.Update(_mapper.Map<Article>(request.Model), cancellationToken);

            return 0;
        }
    }
}
