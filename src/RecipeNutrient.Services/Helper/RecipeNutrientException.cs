using System;
namespace RecipeNutrient.Services.Helper
{
    public class RecipeNutrientException : Exception
    {
        public int StatusCode { get; set; }

        public RecipeNutrientException() : base() { }
        public RecipeNutrientException(string message) : base(message) { }
        public RecipeNutrientException(string message, int StatusCode)
                    : base(message)
        {
            this.StatusCode = StatusCode;
        }

    }
}

