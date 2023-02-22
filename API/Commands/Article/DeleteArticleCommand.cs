
using API.Repositories;
using Domain.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API.Commands
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
        private readonly IRepository<Article> _articleRepository;
        public DeleteArticleCommandHandler(IRepository<Article> articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<Unit> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
        {
            await _articleRepository.Delete(request.Id, cancellationToken);
            return Unit.Value;
        }
    }
}
