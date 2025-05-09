using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI_API_DAL;
using ITI_DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ITI_DAL.Repository
{
    public class UserRepository :  IUserRepository
    {
        protected readonly ITIContext _context;

        public UserRepository(ITIContext context) => _context = context;

        #region Create
        public async Task CreateAsync(User entity) => await _context.Set<User>().AddAsync(entity);
        #endregion
        #region Read
        public Task<List<User>> GetAllAsync() => _context.Set<User>().ToListAsync();

        public async Task<User?> GetByIdAsync(Guid id) => await _context.Set<User>().FindAsync(id);
        #endregion
        #region Update
        public async Task UpdateAsync(User entity) { }

        #endregion
        #region Delete
        public void Delete(User entity) => _context.Set<User>().Remove(entity);

        #endregion
    }
}
