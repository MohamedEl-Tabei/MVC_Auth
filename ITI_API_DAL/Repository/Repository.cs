using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ITI_API_DAL;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly ITIContext _context;
    public Repository(ITIContext context)
    {
        _context = context;
    }

    public void Add(T entity)=> _context.Set<T>().Add(entity);

    public void Delete(T entity)=>_context.Set<T>().Remove(entity);
        

    public List<T> GetAll() => _context.Set<T>().ToList();

    public T GetById(Guid id) => _context.Set<T>().Find(id);
   

    public async Task<T> GetByIdAsync(Guid id)=> await _context.Set<T>().FindAsync(id);
}
