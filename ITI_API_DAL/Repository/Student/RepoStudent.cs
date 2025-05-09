using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ITI_API_DAL;

public class RepoStudent : Repository<Student>, IRepoStudent
{
    public RepoStudent(ITIContext context):base(context) {  }
    public List<Student> GetAllWihCourses()=>_context.Students.Include(s=>s.Courses).AsNoTracking().ToList();

    public Student GetByIdWithCourses(Guid id)
    {
        return _context.Students.Include(s=>s.Courses).FirstOrDefault(s=>s.Id == id);
    }
}
