using API.Repositories;
using AutoMapper;
using Contracts.Dtos;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace API.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IRepository<Article> _articleRepository;
        private IMapper _mapper;

        public ArticleService(IRepository<Article> articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task Add(ArticleDto articleDto)
        {
            await _articleRepository.Insert(_mapper.Map<Article>(articleDto));
        }

        public async Task Delete(int id)
        {
            await _articleRepository.Delete(id);
        }

        public async Task<ArticleDto> Get(int id)
        {
            var article = await _articleRepository.Get(id);
            return _mapper.Map<ArticleDto>(article);
        }

        public async Task<IEnumerable<ArticleDto>> GetAll()
        {
            var articles = await _articleRepository.GetAll();
            return articles.Select(x => _mapper.Map<ArticleDto>(x));
        }

        public async Task<IEnumerable<ArticleDto>> GetBy(Expression<Func<Article, bool>> predycate)
        {
            var articles = await _articleRepository.GetByFilter(predycate);
            return articles.Select(x => _mapper.Map<ArticleDto>(x));
        }

        public async Task Update(ArticleDto articleDto)
        {
            var article = _mapper.Map<Article>(articleDto);
            await _articleRepository.Update(article);
        }
    }
}
