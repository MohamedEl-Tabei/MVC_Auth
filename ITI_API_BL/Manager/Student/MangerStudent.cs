using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI_API_BL.DTO.Student;
using ITI_API_DAL;

namespace ITI_API_BL;

public class MangerStudent : IManagerStudent
{
    private readonly IUnitOfWork Repo;
    public MangerStudent(IUnitOfWork repo)
    {
        Repo = repo;
    }

    public void Add(DTOStudentCreate s)
    {
        Repo.Student.Add(new Student
        {
            Address = s.Address,
            Age = s.Age,
            Name = s.Name,
            DepartmentId=s.DepartmentId
        });
        Repo.SaveChanges();
    }


    public void Delete(Guid id)
    {
        var student = Repo.Student.GetByIdWithCourses(id);
        Repo.Student.Delete(student);
        Repo.SaveChanges();
    }

    public List<DTOStudentRead> GetAll()
    {
        var students = Repo.Student.GetAllWihCourses();
        return students.Select(s => new DTOStudentRead
        {
            Address = s.Address,
            Age = s.Age,
            Id = s.Id,
            Name = s.Name,
            Courses = s.Courses.Select(c => new DTOStudentReadCourse { id = c.Id, Name = c.Name }).ToList(),

        }).ToList();
    }

    public DTOStudentRead GetById(Guid id)
    {
        var student = Repo.Student.GetByIdWithCourses(id);
        return new DTOStudentRead
        {
            Address = student.Address,
            Age = student.Age,
            Id = student.Id,
            Name = student.Name,
            DepartmentId=student.DepartmentId,
            Courses = student.Courses.Select(s => new DTOStudentReadCourse { id = s.Id, Name = s.Name }).ToList(),
        };
    }

    public async Task<DTOStudentRead> GetByIdAsync(Guid id)
    {
        var student = await Repo.Student.GetByIdAsync(id);
        return new DTOStudentRead
        {
            Address = student.Address,
            Age = student.Age,
            Id = student.Id,
            Name = student.Name,
            Courses = student.Courses.Select(s => new DTOStudentReadCourse { id = s.Id, Name = s.Name }).ToList(),
        };
    }


    public void Update(Guid id, DTOStudentRead newData)
    {
        var student = Repo.Student.GetById(id);
        student.Address = newData.Address;
        student.Age = newData.Age;
        student.Name = newData.Name;
        student.DepartmentId=newData.DepartmentId;
        Repo.SaveChanges();
    }
}
