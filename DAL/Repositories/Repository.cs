using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using System.Linq;

namespace DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Gets or sets database set of entity type
        /// </summary>
        private readonly DbSet<TEntity> dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}" /> class.
        /// </summary>
        /// <param name="context">timer context instance</param>
        public Repository(ShopContext context)
        {
            ShopContext = context;
            dbSet = context.Set<TEntity>();
        }

        /// <summary>
        /// Gets or sets timer context
        /// </summary>
        ShopContext ShopContext{ get; set; }

        public IEnumerable<TEntity> GetAllEntities()
        {
            return dbSet;
        }

        public IEnumerable<TEntity> GetAllEntitiesByFilter(Func<TEntity, bool> filter)
        {
            return dbSet.Where(filter);
        }

        public TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public void Create(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public void Delete(TEntity entityToDelete)
        {
            if (ShopContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }

            dbSet.Remove(entityToDelete);
        }

        public void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            ShopContext.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public void Save()
        {
            ShopContext.SaveChanges();
        }
    }
}
