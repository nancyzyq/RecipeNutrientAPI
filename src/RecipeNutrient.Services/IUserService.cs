using System;
using RecipeNutrient.Data.Model;
using RecipeNutrient.Data.Repository;
using RecipeNutrient.Services.Model;

namespace RecipeNutrient.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        Task<User> Register(User user);
        Task UpdateUser(User user);
        Task DeleteUser(User user);
        IList<User> GetUsers();
        User GetUserById(int id);
    }
}

