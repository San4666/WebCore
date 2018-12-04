using System.Collections.Generic;

namespace WebCore.Repositories
{
    public interface IBaseRepository<TEntity> : IExistRepository
    {
        TEntity Find(int id);
        
        void Insert(TEntity entity);
        
        void Update(TEntity entity);
        
        void Delete(TEntity entity);
        
        ICollection<TEntity> All();
    }
}