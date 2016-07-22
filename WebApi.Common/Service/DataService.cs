using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using WebApi.Common.DataAccess;
using WebApi.Common.Domain;

namespace WebApi.Common.Service
{
    public class DataService : IDataService
    {
        protected IAnyDbContext DbContext;

        public DataService(IAnyDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public bool Exists<T>(Expression<Func<T, bool>> match) where T : Entity
        {
            return DbContext.EntitieSet<T>().SingleOrDefault(match) != null;
        }

        public T FindOne<T>(Expression<Func<T, bool>> predicate, QueryOption option = QueryOption.AsNoTracking,
            params Expression<Func<T, object>>[] includes) where T : Entity
        {
            IQueryable<T> query = DbContext.EntitieSet<T>();

            if (includes != null)
                query = includes.Aggregate(query, (current, include) => option == QueryOption.None ? current.Include<T, object>(include) : current.Include<T, object>(include).AsNoTracking());

            return option == QueryOption.None ? query.FirstOrDefault(predicate) : query.AsNoTracking().FirstOrDefault(predicate);
        }

        public IEnumerable<T> Find<T>(Expression<Func<T, bool>> predicate, QueryOption option = QueryOption.None) where T : Entity
        {
            IQueryable<T> query = DbContext.EntitieSet<T>();

            return option == QueryOption.None ? query.Where(predicate) : query.AsNoTracking().Where(predicate);
        }

        public IQueryable<T> GetAll<T>() where T : Entity
        {
            return DbContext.EntitieSet<T>();
        }

        public IEnumerable<T> GetAll<T>(QueryOption option) where T : Entity
        {
            IQueryable<T> query = DbContext.EntitieSet<T>();

            return option == QueryOption.None ? query.ToList() : query.AsNoTracking().ToList();
        }

        public virtual void Delete<T>(T entity) where T : Entity
        {
            DbContext.EntitieSet<T>().Remove(entity);
        }

        public void DeleteAll<T>(IEnumerable<T> entities) where T : Entity
        {
            foreach (var entity in entities)
            {
                DbContext.EntitieSet<T>().Remove(entity);
            }
        }

        public void Add<T>(T entity) where T : Entity
        {
            DbContext.EntitieSet<T>().Add(entity);
        }

        public void Update<T>(T entity) where T : Entity
        {
            var entry = DbContext.GetEntry(entity);

            entry.State = EntityState.Modified;
        }

        public void UpdateProperties<T>(T entity, params Expression<Func<T, object>>[] properties) where T : Entity
        {
            DbContext.EntitieSet<T>().Attach(entity);

            var entry = DbContext.GetEntry(entity);

            foreach (var property in properties)
            {
                var propertyName = GetPropertyName(property);

                entry.Property(propertyName).IsModified = true;
            }
        }

        public void Save()
        {
            DbContext.Save();
        }

        /// <summary>
        ///     Returns the name of the specified property of the specified type.
        /// </summary>
        /// <typeparam name="T">
        ///     The type the property is a member of.
        /// </typeparam>
        /// <param name="property">
        ///     The property.
        /// </param>
        /// <returns>
        ///     The property name.
        /// </returns>
        private static string GetPropertyName<T>(Expression<Func<T, object>> property) where T : Entity
        {
            var lambda = (LambdaExpression)property;
            MemberExpression memberExpression;

            if (lambda.Body is UnaryExpression)
            {
                var unaryExpression = (UnaryExpression)lambda.Body;
                memberExpression = (MemberExpression)unaryExpression.Operand;
            }
            else
            {
                memberExpression = (MemberExpression)lambda.Body;
            }

            return memberExpression.Member.Name;
        }
    }
}
