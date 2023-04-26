
using Microsoft.EntityFrameworkCore;
using SampleWithReact.Application.Common.Interfaces.Persistence.Common;
using SampleWithReact.Domain.Entities.Commnon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SampleWithReact.Infrastructure.Persistence.Repositories.Common
{
    public class EFRepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        public SampleWithReactDbContext _context { get; set; }
        public EFRepositoryBase(SampleWithReactDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        protected DbSet<TEntity> _dbSet { get; set; }
        public TEntity Entity { get; set; }

        public TEntity GetById(long id, bool ShowDeleted = false)
        {
            if (id != null)
            {
                if (ShowDeleted == false)
                {
                    return _context.Set<TEntity>().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault();
                }
                else
                {
                    return _context.Set<TEntity>().Where(x => x.Id == id).FirstOrDefault()!;
                }
            }
            throw new Exception("Id is Null", new Exception(HttpStatusCode.BadRequest.ToString()));
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter, bool FetchDeletedRows = false)
        {
            return filter == null
                ? _context.Set<TEntity>().ToList()
                : _context.Set<TEntity>().Where(filter).ToList();
        }

        public List<TEntity> Get(int queryPage, int querySize)
        {
            return _dbSet.Skip((queryPage - 1) * querySize).Take(querySize).ToList();
        }

        public TEntity Add(TEntity entity)
        {
            var result = _dbSet.Add(entity);
            return result.Entity;
        }

        public int Count()
        {
            return _dbSet.Count();
        }

        public void Delete(long id)
        {
            TEntity entity = GetById(id, true);

            if (entity == null)
                throw new Exception("Silinecek öğe bulunamadı", new Exception(HttpStatusCode.BadRequest.ToString()));
        }

      

        public IQueryable<TEntity> GetAll()
        {
           return _dbSet.AsNoTracking<TEntity>().Where(x=>x.IsDeleted == false);
        }

        public TEntity Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            return entity;
        }

        public TEntity Update(TEntity entity, bool deletion = false)
        {
            _dbSet.Update(entity);
            return entity;
        }
    }

}
