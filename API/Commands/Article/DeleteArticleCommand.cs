using API.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Commands.Article
{
    public class DeleteArticleCommand : IRequest
    {
        public int Id { get; set; }
        public DeleteArticleCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand>
    {
        private readonly IArticleService _articleSevice;
        public DeleteArticleCommandHandler(IArticleService articleSevice)
        {
            _articleSevice = articleSevice;
        }

        public async Task<Unit> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
        {
            await _articleSevice.Delete(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
