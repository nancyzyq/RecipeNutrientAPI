using System;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace RecipeNutrient.Services.Helper
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (RecipeNutrientException e)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                // switch(error)
                // {
                //     case AppException e:
                //         // custom application error
                //         response.StatusCode = (int)HttpStatusCode.BadRequest;
                //         break;
                //     case KeyNotFoundException e:
                //         // not found error
                //         response.StatusCode = (int)HttpStatusCode.NotFound;
                //         break;
                //     default:
                //         // unhandled error
                //         response.StatusCode = (int)HttpStatusCode.InternalServerError;
                //         break;
                // }
                response.StatusCode = e.StatusCode;
                //if (e is RecipeNutrientException)
                //{
                    
                //}
                //else
                //{
                //    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                //}
                var result = JsonSerializer.Serialize(new { message = e?.Message });
                await response.WriteAsync(result);
            }
            catch (Exception e)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var result = JsonSerializer.Serialize(new { message = e?.Message });
                await response.WriteAsync(result);
            }
        }
    }
}

