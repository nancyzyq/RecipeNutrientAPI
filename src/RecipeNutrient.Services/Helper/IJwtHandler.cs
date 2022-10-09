using System;
using RecipeNutrient.Data.Model;

namespace RecipeNutrient.Services.Helper
{
    public interface IJwtHandler
    {
        string GenerateToken(User user);
    }
}

