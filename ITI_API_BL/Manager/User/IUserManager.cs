using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ITI_BL.DTO.User;

namespace ITI_BL.Manager.User
{
    public interface IUserManager
    {
        public Task<List<UserRead>> GetAllAsync();
        public Task<Token> GenerateTokenAsync(List<Claim> claims);
    }
}
