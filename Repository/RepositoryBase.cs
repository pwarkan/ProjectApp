using Entities;
using Microsoft.EntityFrameworkCore;
using References;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Repository
{
    //Базовый репозиторий от которого наследуются другие репозитории
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected CarServiceContext CarServiceContext;

        public RepositoryBase(CarServiceContext carServiceContext)
        {
            CarServiceContext = carServiceContext;
        }

        public void Create(T entity)
        {
            CarServiceContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            CarServiceContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges) =>
            (!trackChanges) ?
              CarServiceContext.Set<T>()
                .AsNoTracking() :
              CarServiceContext.Set<T>();

        //AsNoTracking используется, чтобы данные не помещались в кэш, ef не выделяет дополнительное место для извлечения объектов из БД
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            (!trackChanges) ?
              CarServiceContext.Set<T>()
                .Where(expression)
                .AsNoTracking() :
              CarServiceContext.Set<T>()
                .Where(expression);

        public void Update(T entity)
        {
            CarServiceContext.Set<T>().Update(entity);
        }
    }
}
