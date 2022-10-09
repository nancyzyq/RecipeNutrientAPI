using System;
using RecipeNutrient.Data.Model;

namespace RecipeNutrient.Services
{
    public interface IUnitService
    {
        Task<Unit> InsertUnit(Unit unit);
        Task UpdateUnit(Unit unit);
        Task DeleteUnit(Unit unit);
        IList<Unit> GetUnits();
        Unit GetUnitById(int id);
    }
}

