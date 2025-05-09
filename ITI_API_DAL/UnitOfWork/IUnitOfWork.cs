using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI_API_DAL;

public interface IUnitOfWork
{
    public IRepoStudent Student {get; }
    public IRepoCourse Course { get; }
    public IDepartmentRepo Department { get; }
    public Task<int> SaveChangesAsync();
    public int SaveChanges();
}
