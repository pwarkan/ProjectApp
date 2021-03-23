using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace References
{
    //интерфейс базового репозитория
    public interface IRepositoryBase<T>
    {
        //Найти все записи
        IQueryable<T> FindAll(bool trackChanges);

        //Найти записи по определенному условию
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);

        //Создать сущность
        void Create(T entity);

        //Редактировать сущность
        void Update(T entity);

        //Удалить сущность
        void Delete(T entity);
    }
}
