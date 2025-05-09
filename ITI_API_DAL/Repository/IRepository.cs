using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI_API_DAL;

public interface IRepository<T>
{
    List<T> GetAll();
    Task<T> GetByIdAsync(Guid id);
    T GetById(Guid id);
    void Delete(T entity);
    void Add(T entity);


}
