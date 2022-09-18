using System;
using System.Linq.Expressions;
using RecipeNutrient.Data.Model;

namespace RecipeNutrient.Data.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> Insert(T model);
        Task Insert(IEnumerable<T> modeList);
        Task Update(T model);
        //void Update(T model, List<string> properties);
        Task Delete(T model);
        //void Delete(Expression<Func<T, bool>> whereLambda);
        IQueryable<T> GetList();
        IQueryable<T> GetEntities(Expression<Func<T, bool>> expression);
        T GetEntityById(int id);
        //T? GetEntity(Expression<Func<T, bool>> whereLambda);
    }
}

