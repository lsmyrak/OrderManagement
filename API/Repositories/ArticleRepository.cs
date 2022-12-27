using Domain.Model;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
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
        public async Task<Article> Get(int id, CancellationToken cancellationToken)
        {
            var article = await _context.Article.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted==false , cancellationToken);
            if (article == null)
            {
                return new Article();
            }
            return article;
        }

        public async Task<IEnumerable<Article>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Article.Where(x => x.IsDeleted == false).ToArrayAsync(cancellationToken);
        }

        public async Task Insert(Article entity, CancellationToken cancellationToken)
        {
            _context.Article.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            var article = await _context.Article.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            if (article != null)
            {
                _context.Article.Remove(article);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task Update(Article entity, CancellationToken cancellationToken)
        {
            _context.Article.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

        }

        public async Task<IEnumerable<Article>> GetBy(Expression<Func<Article, bool>> predycate, CancellationToken cancellationToken)
        {
            var articles = new List<Article>();
            try
            {
                articles = await _context.Article.Where(x => x.IsDeleted == false).ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                ExceptionDispatchInfo.Capture(e).Throw();
            }
            if (predycate != null)
            {
                var cc = articles.AsQueryable<Article>();
                cc.Where(predycate);

                return await cc.ToListAsync<Article>(cancellationToken);
            }
            return articles;
        }
    }
}
