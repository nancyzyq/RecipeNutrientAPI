using System;
using RecipeNutrient.Data.Model;
using RecipeNutrient.Data.Repository;

namespace RecipeNutrient.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Category> InsertCategory(Category category)
        {
            return await _categoryRepository.Insert(category);
        }
        public async Task UpdateCategory(Category category)
        {
            await _categoryRepository.Update(category);
        }
        //public async Task DeleteCategory(Category category)
        //{
        //    await _categoryRepository.Delete(category);
        //}
        public async Task DeleteCategory(Category category)
        {
            category.Deleted = true;
            await _categoryRepository.Update(category);
        }
        public IList<Category> GetCategories()
        {
            return _categoryRepository.GetEntities(c => c.Deleted == false).ToList();
        }
        public Category GetCategoryById(int id)
        {
            return _categoryRepository.GetEntityById(id);
        }
    }
}

