using Contracts.Dtos;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace API.Services.Interfaces
{
    public interface IArticleService
    {
        public Task Add(ArticleDto articleDto, CancellationToken cancellationToken);
        public Task<ArticleDto> Get(int id, CancellationToken cancellationToken);
        public Task<IEnumerable<ArticleDto>> GetAll(CancellationToken cancellationToken);
        public Task Delete(int id, CancellationToken cancellationToken);
        public Task Update(ArticleDto articleDto, CancellationToken cancellationToken);
        public Task<IEnumerable<ArticleDto>> GetBy(Expression<Func<Article, bool>> predycate, CancellationToken cancellationToken);
        public Task<IEnumerable<ArticleDto>> GetByFilter(string filter, CancellationToken cancellationToken);

    }
}
