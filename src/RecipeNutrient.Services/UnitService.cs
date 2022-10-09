using System;
using RecipeNutrient.Data.Model;
using RecipeNutrient.Data.Repository;

namespace RecipeNutrient.Services
{
    public class UnitService : IUnitService
    {
        private readonly IRepository<Unit> _unitRepository;

        public UnitService(IRepository<Unit> unitRepository)
        {
            _unitRepository = unitRepository;
        }
        public async Task<Unit> InsertUnit(Unit unit)
        {
            return await _unitRepository.Insert(unit);
        }
        public async Task UpdateUnit(Unit unit)
        {
            await _unitRepository.Update(unit);
        }
        public async Task DeleteUnit(Unit unit)
        {
            unit.Deleted = true;
            await _unitRepository.Update(unit);
        }
        public IList<Unit> GetUnits()
        {
            return _unitRepository.GetEntities(u => u.Deleted == false).ToList();
        }
        public Unit GetUnitById(int id)
        {
            return _unitRepository.GetEntityById(id);
        }
    }
}

