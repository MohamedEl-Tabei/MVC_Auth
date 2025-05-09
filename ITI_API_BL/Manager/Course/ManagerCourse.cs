using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI_API_DAL;

namespace ITI_API_BL;

public class ManagerCourse : IManagerCourse
{
    private readonly IUnitOfWork Repo;
    public ManagerCourse(IUnitOfWork repo)
    {
       Repo=repo;
    }
    public  List<Course> GetAll() => Repo.Course.GetAll();
}
