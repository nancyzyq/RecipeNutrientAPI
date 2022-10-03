using System;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using RecipeNutrient.Data.Model;
using RecipeNutrient.Services.Model;

namespace RecipeNutrient.Services
{
    
    public class JwtHandler : IJwtHandler
    {
        private JwtSetting _jwtSetting;

        public JwtHandler(IOptions<JwtSetting> jwtSetting)
        {
            _jwtSetting = jwtSetting.Value;
        }

        public string GenerateToken(User user)
        {
            //Console.WriteLine(user.Role.Name);
            var claims = new[] {
                                    new Claim("Id", user.Id.ToString()),
                                    new Claim(ClaimTypes.Role, user.Role.Name)
                                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.Key));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _jwtSetting.Issuer,
                audience: _jwtSetting.Audience,
                claims,
                expires: DateTime.UtcNow.AddMinutes(120),
                signingCredentials: signIn
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

