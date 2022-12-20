using Domain.Model;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class ArticleRepository : IRepository<Article>
    {
        private readonly OrderContext _context;
        public ArticleRepository(OrderContext context)
        {
            _context = context;
        }
        public async Task<Article> Get(int id)
        {
            var article = await _context.Article.FirstOrDefaultAsync(x => x.Id == id);
            if (article == null)
            {
                return new Article();
            }
            return article;
        }

        public async Task<IEnumerable<Article>> GetAll()
        {
            return await _context.Article.Where(x => x.IsDeleted == false).ToArrayAsync();
        }

        public async Task Insert(Article entity)
        {
            _context.Article.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var article = await _context.Article.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            if (article != null)
            {
                _context.Article.Remove(article);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Update(Article entity)
        {
            _context.Article.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Article>> GetByFilter(Expression<Func<Article, bool>> predycate)
        {
            var articles = new List<Article>();
            try
            {
                articles = await _context.Article.Where(x => x.IsDeleted == false).ToListAsync();                       
            }
            catch (Exception e)
            {
                ExceptionDispatchInfo.Capture(e).Throw();
            }
            if (predycate != null)
            {
                var cc = articles.AsQueryable<Article>();
                cc.Where(predycate);

                return await cc.ToListAsync<Article>();
            }
            return articles;
        }
    }
}
