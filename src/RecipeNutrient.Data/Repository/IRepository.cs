using System;
using RecipeNutrient.Data.Model;

namespace RecipeNutrient.Data.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task Insert(T model);
        Task Insert(IEnumerable<T> modeList);
        Task Update(T model);
        //void Update(T model, List<string> properties);
        Task Delete(T model);
        //void Delete(Expression<Func<T, bool>> whereLambda);
        IQueryable<T> GetList();
        T GetEntityById(int id);
        //T? GetEntity(Expression<Func<T, bool>> whereLambda);
    }
}

