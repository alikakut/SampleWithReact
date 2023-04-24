using SampleWithReact.Domain.Entities.Commnon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SampleWithReact.Application.Common.Interfaces.Persistence.Common
{
    public interface IRepositoryBase <TEntity> where TEntity : BaseEntity
    {
        TEntity GetById(long id, bool ShowDeleted = false);
        List<TEntity> GetList(Expression<Func<TEntity, bool>> filter, bool FetchDeletedRows = false);
        List<TEntity> Get(int queryPage, int querySize);
        TEntity Add(TEntity entity);
        TEntity Delete(TEntity entity);
        int Count();
        void Delete(long id);
        TEntity Update(TEntity entity, bool deletion=false);
        public IQueryable<TEntity> GetAll();

    }
}
