using System;
using AutoMapper;
using RecipeNutrient.Data.Model;
using RecipeNutrient.Services.Model;

namespace RecipeNutrient.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // User -> AuthenticateResponse
            CreateMap<User, AuthenticateResponse>();

        }
    }
}

