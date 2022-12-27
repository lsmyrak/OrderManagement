using API.Repositories;
using API.Services.Interfaces;
using AutoMapper;
using Contracts.Dtos;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace API.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IRepository<Article> _articleRepository;
        private readonly IMapper _mapper;

        public ArticleService(IRepository<Article> articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task Add(ArticleDto articleDto, CancellationToken cancellationToken)
        {
            await _articleRepository.Insert(_mapper.Map<Article>(articleDto));
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _articleRepository.Delete(id, cancellationToken);
        }

        public async Task<ArticleDto> Get(int id, CancellationToken cancellationToken)
        {
            var article = await _articleRepository.Get(id, cancellationToken);
            return _mapper.Map<ArticleDto>(article);
        }

        public async Task<IEnumerable<ArticleDto>> GetAll(CancellationToken cancellationToken)
        {
            var articles = await _articleRepository.GetAll(cancellationToken);
            return articles.Select(x => _mapper.Map<ArticleDto>(x));
        }

        public async Task<IEnumerable<ArticleDto>> GetBy(Expression<Func<Article, bool>> predycate, CancellationToken cancellationToken)
        {
            var articles = await _articleRepository.GetBy(predycate,cancellationToken);
            return articles.Select(x => _mapper.Map<ArticleDto>(x));
        }

        public async Task<IEnumerable<ArticleDto>> GetByFilter(string filter,CancellationToken cancellationToken)
        {
            var articles = await _articleRepository.GetAll(cancellationToken);
           
            var searchArticles = articles
                .Where(x => x.Name.Contains(filter)
                || x.NettoPrice.ToString().Contains(filter)
                || x.GrossPrice.ToString().Contains(filter)
                || x.Tax.ToString().Contains(filter));
            
            return searchArticles.Select(x=>_mapper.Map<ArticleDto>(x));

        }

        public async Task Update(ArticleDto articleDto,CancellationToken cancellationToken)
        {

            var articleSrc = await _articleRepository.Get(articleDto.Id, cancellationToken);
            var article = _mapper.Map<ArticleDto,Article>(articleDto,articleSrc);
            await _articleRepository.Update(article,cancellationToken);
        }
    }
}
