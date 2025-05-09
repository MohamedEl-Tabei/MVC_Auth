using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ITI_BL.DTO.User;
using ITI_BL.Manager.User;
using ITI_DAL.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ITI_BL.Manager
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _repositories;
        private readonly IConfiguration _cofigration;

        public UserManager(IUserRepository repositories, IConfiguration configuration)
        {
            _repositories = repositories;

            _cofigration = configuration;
        }

        public async Task<Token?> GenerateTokenAsync(List<Claim> claims)
        {

            var secretKey = _cofigration["secretKey"];
            var secretKeyInBytes = Encoding.UTF8.GetBytes(secretKey);
            var key = new SymmetricSecurityKey(secretKeyInBytes);

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddHours(1),
                claims: claims,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );
            return new Token() { JWT = new JwtSecurityTokenHandler().WriteToken(token), Expire = token.ValidTo };
        }

        public async Task<List<UserRead>> GetAllAsync()
        {
            var users = await _repositories.GetAllAsync();
            return users.Select(u => new UserRead
            {
                Email = u.Email,
                Id = u.Id,
                Name = u.Name,
            }).ToList();
        }




    }
}
