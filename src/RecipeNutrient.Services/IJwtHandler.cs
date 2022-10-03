using System;
using RecipeNutrient.Data.Model;

namespace RecipeNutrient.Services
{
    public interface IJwtHandler
    {
        string GenerateToken(User user);
    }
}

