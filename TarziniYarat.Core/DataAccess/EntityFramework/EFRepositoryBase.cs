using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TarziniYarat.Core.Model;

namespace TarziniYarat.Core.DataAccess.EntityFramework
{
    public class EFRepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TContext : DbContext, new()
        where TEntity : BaseEntity
    {
        TContext db;
        DbSet<TEntity> entities;
        public EFRepositoryBase()
        {
            db = SingletonContext<TContext>.Context;
            entities = db.Set<TEntity>();
        }
        public int Add(TEntity entity)
        {
            entities.Add(entity);
            return db.SaveChanges();
        }

        public int Delete(TEntity entity)
        {
            entities.Remove(entity);
            return db.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return entities.SingleOrDefault(filter);
        }

        public ICollection<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter != null)
            {
                return entities.Where(filter).ToList();
            }
            else
            {
                return entities.ToList();
            }
        }

        public int Update(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges();
        }
    }
}
