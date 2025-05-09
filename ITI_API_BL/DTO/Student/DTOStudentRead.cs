using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI_API_DAL;

namespace ITI_API_BL;

public class DTOStudentRead
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public int Age { get; set; }
    public Guid DepartmentId {  get; set; }
    public ICollection<DTOStudentReadCourse>? Courses { get; set; }
}
public class DTOStudentReadCourse
{
    public Guid id { get; set; }
    public string Name { get; set; }
}