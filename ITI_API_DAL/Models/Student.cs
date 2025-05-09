using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI_API_DAL.Models;

namespace ITI_API_DAL;

public class Student
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public int Age  { get; set; }
    public Guid DepartmentId { get; set; }

    public Department Department { get; set; }
    public ICollection<Course>? Courses { get; set; }
}
