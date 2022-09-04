﻿using System;
using Microsoft.EntityFrameworkCore;
using RecipeNutrient.Data.Model;

namespace RecipeNutrient.Data.Repository
{
    public class RecipeNutrientRepository<T> : IRepository<T> where T : BaseEntity
    {
        private RecipeNutrientDbContext _RecipeNutrientDbContext;
        public RecipeNutrientRepository(RecipeNutrientDbContext RecipeNutrientDbContext)
        {
            _RecipeNutrientDbContext = RecipeNutrientDbContext;
        }
        public async Task Insert(T model)
        {
            _RecipeNutrientDbContext.Set<T>().Add(model);
            await _RecipeNutrientDbContext.SaveChangesAsync();
        }
        public async Task Insert(IEnumerable<T> modeList)
        {
            _RecipeNutrientDbContext.Set<T>().AddRange(modeList);
            await _RecipeNutrientDbContext.SaveChangesAsync();
        }
        public async Task Update(T model)
        {
            _RecipeNutrientDbContext.Entry<T>(model).State = EntityState.Modified;
            await _RecipeNutrientDbContext.SaveChangesAsync();
        }
        //public void Update(T model, List<string> properties)
        //{

        //}
        public async Task Delete(T model)
        {
            _RecipeNutrientDbContext.Set<T>().Remove(model);
            await _RecipeNutrientDbContext.SaveChangesAsync();
        }
        public IQueryable<T> GetList()
        {
            return _RecipeNutrientDbContext.Set<T>();
        }
        public T GetEntityById(int id)
        {
            return _RecipeNutrientDbContext.Set<T>().Find(id);
        }
    }
}
