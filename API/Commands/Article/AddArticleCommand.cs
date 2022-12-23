using API.Services;
using Contracts.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Commands.Article
{
    public class AddArticleCommand : IRequest<int>
    {
        public ArticleDto model { get; set; }

        public AddArticleCommand(ArticleDto model)
        {
            this.model = model;
        }
    }

    public class AddArticvleCommandHandler : IRequestHandler<AddArticleCommand, int>
    {
        private readonly IArticleService _articleService;
        public AddArticvleCommandHandler(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<int> Handle(AddArticleCommand request, CancellationToken cancellationToken)
        {
            ArticleDto model = request.model;
            if (model == null)
            {
                return 1;
            }
            await _articleService.Add(model,cancellationToken);
            return 0;
        }
    }
}
