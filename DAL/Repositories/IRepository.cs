using System;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public interface IRepository<TEntity>
    {

        IEnumerable<TEntity> GetAllEntities();

        IEnumerable<TEntity> GetAllEntitiesByFilter(Func<TEntity, bool> filter);

        TEntity GetByID(object id);

        void Create(TEntity entity);

        void Delete(object id);

        void Delete(TEntity entityToDelete);

        void Update(TEntity entityToUpdate);

        void Save();
    }
}
