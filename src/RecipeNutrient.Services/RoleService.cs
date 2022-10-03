using System;
using RecipeNutrient.Data.Model;
using RecipeNutrient.Data.Repository;

namespace RecipeNutrient.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRepository<Role> _roleRepository;

        public RoleService(IRepository<Role> roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task<Role> InsertRole(Role role)
        {
            return await _roleRepository.Insert(role);
        }
        public async Task UpdateRole(Role role)
        {
            await _roleRepository.Update(role);
        }
        public async Task DeleteRole(Role role)
        {
            role.Deleted = true;
            await _roleRepository.Update(role);
        }
        public IList<Role> GetRoles()
        {
            return _roleRepository.GetEntities(r => r.Deleted == false).ToList();
        }
        public Role GetRoleById(int id)
        {
            return _roleRepository.GetEntityById(id);
        }
    }
}

