using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI_API_DAL;

public interface IRepoStudent:IRepository<Student>
{
    public List<Student> GetAllWihCourses();
    public Student GetByIdWithCourses(Guid id);

}
