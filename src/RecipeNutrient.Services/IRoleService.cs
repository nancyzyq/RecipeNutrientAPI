using System;
using RecipeNutrient.Data.Model;

namespace RecipeNutrient.Services
{
    public interface IRoleService
    {
        Task<Role> InsertRole(Role role);
        Task UpdateRole(Role role);
        Task DeleteRole(Role role);
        IList<Role> GetRoles();
        Role GetRoleById(int id);
    }
}

