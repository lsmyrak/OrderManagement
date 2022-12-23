using API.Services;
using Contracts.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace API.Commands.Article
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
        private readonly IArticleService _articleService;

        public UpdateArticleCommandHandler(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<int> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            await _articleService.Update(request.Model, cancellationToken);

            return 0;
        }
    }
}
