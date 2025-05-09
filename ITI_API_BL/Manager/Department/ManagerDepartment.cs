using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI_API_DAL;
using ITI_API_DAL.Models;

namespace ITI_API_BL.Manager;

internal class ManagerDepartment:IMangerDepartment
{
    public IUnitOfWork Repo { get; }
    public ManagerDepartment(IUnitOfWork repo)
    {
        Repo = repo;
    }


    public List<Department> GetAll() => Repo.Department.GetAll();
}
