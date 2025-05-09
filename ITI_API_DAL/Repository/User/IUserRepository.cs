using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI_DAL.Models;

namespace ITI_DAL.Repository
{
    public interface IUserRepository
    {
            public Task<List<User>> GetAllAsync();
            public Task<User?> GetByIdAsync(Guid id);
            public Task CreateAsync(User entity);
            public Task UpdateAsync(User entity);
            public void Delete(User entity);
    }
}
