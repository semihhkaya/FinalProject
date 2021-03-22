using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //Generic Constraint
    //class: referans tip olabilir
    //IEntity: IEntity interface'i de olabilir. Veya: IEntity'i implemente eden bir nesne,class vs. olabilir.
    //newlenebilir olmalı. (IEntity'i devre dışı bıraktık. IEntity'i parametre olarak veremiyoruz.)

    //ORM, EF(EntityFramework), CRUD Operation
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
