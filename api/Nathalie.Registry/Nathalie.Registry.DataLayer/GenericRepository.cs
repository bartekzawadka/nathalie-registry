using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Nathalie.Registry.DataLayer
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        private const string IdPropertyName = "Id";
        
        internal NathalieRegistryContext Context;
        internal DbSet<TEntity> DbSet;

        public GenericRepository(NathalieRegistryContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetList()
        {
            return DbSet;
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includeNavigations = null)
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeNavigations != null && includeNavigations.Any())
            {

                foreach (Expression<Func<TEntity, object>> expression in includeNavigations)
                {
                    query = query.Include(expression);
                }
            }

            return orderBy != null ? orderBy(query).ToList() : query.ToList();
        }
        
        public virtual TEntity GetByIdWithIncludes(object id, List<Expression<Func<TEntity, object>>> includeNavigations = null )
        {

            var parameter = Expression.Parameter(typeof(TEntity), "e");
            var predicate = Expression.Lambda<Func<TEntity, bool>>(
                Expression.Equal(
                    Expression.PropertyOrField(parameter, IdPropertyName),
                    Expression.Constant(id)),
                parameter);


           
            IQueryable<TEntity> query = DbSet;

            if (includeNavigations != null && includeNavigations.Any())
            {

                foreach (Expression<Func<TEntity, object>> expression in includeNavigations)
                {
                    query = query.Include(expression);
                }
            }

            return query.SingleOrDefault(predicate);
        }
        
        public virtual TEntity GetByIdWithInclude(object id, Expression<Func<TEntity, object>> includeNavigation = null)
        {
            List<Expression<Func<TEntity, object>>> includeNavigations = null;
            if (includeNavigation != null)
            {
                includeNavigations = new List<Expression<Func<TEntity, object>>> {includeNavigation};
            }

            return GetByIdWithIncludes(id, includeNavigations);
        }
        
        public virtual TEntity GetById(object id)
        {           
            return GetByIdWithInclude(id);
        }

        public virtual void Insert(TEntity entity)
        {
            
            DbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }
    }
}