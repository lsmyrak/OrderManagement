using Contracts.Dtos;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IArticleService
    {
        public Task Add(ArticleDto articleDto);
        public Task<ArticleDto> Get(int id);
        public Task<IEnumerable<ArticleDto>> GetAll();
        public Task Delete(int id);
        public Task Update(ArticleDto articleDto);
        public Task<IEnumerable<ArticleDto>> GetBy(Expression<Func<Article, bool>> predycate);

    }
}
