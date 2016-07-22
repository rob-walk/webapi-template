using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebApi.Common.Domain;

namespace WebApi.Common.Service
{
    public interface IDataService
    {
        bool Exists<T>(Expression<Func<T, bool>> match) where T : Entity;
        T FindOne<T>(Expression<Func<T, bool>> predicate, QueryOption option = QueryOption.None,
            params Expression<Func<T, object>>[] includes) where T : Entity;
        IEnumerable<T> Find<T>(Expression<Func<T, bool>> predicate, QueryOption option = QueryOption.None)
            where T : Entity;
        IQueryable<T> GetAll<T>() where T : Entity;
        IEnumerable<T> GetAll<T>(QueryOption option) where T : Entity;
        void Delete<T>(T entity) where T : Entity;
        void DeleteAll<T>(IEnumerable<T> entities) where T : Entity;
        void Add<T>(T entity) where T : Entity;
        void Update<T>(T entity) where T : Entity;
        void UpdateProperties<T>(T entity, params Expression<Func<T, object>>[] properties) where T : Entity;
        void Save();
    }
}
