using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI_API_DAL.Models;
using ITI_DAL.Models;
using ITI_DAL.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ITI_API_DAL;

public static class DAL_Extensions
{

    public static void AddDALServices(this IServiceCollection services,IConfiguration configuration )
    {
        services.AddDefaultIdentity<User>(options => { }).AddEntityFrameworkStores<ITIContext>();
        services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/Account/Login";
            options.AccessDeniedPath = "/Account/AccessDenied";
        });
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IRepoStudent, RepoStudent>();
        services.AddScoped<IRepoCourse, RepoCourse>();
        services.AddScoped<IDepartmentRepo, RepoDepartment>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddDbContext<ITIContext>(options=>options
        //.UseSeeding((context, _) =>
        //{
        //    if (context.Set<Student>().Any()) return;
        //    List<Student> students = new List<Student>()
        //    {
        //        new Student {Name="Ali",Address="ISM",Age=28},
        //        new Student {Name="Ahmed",Address="ISM",Age=20},
        //        new Student {Name="Basem",Address="ISM",Age=21},
        //        new Student {Name="Mohamed",Address="ISM",Age=23},
        //        new Student {Name="Karim",Address="ISM",Age=28},
        //        new Student {Name="Omer",Address="ISM",Age=23},
        //        new Student {Name="Amr",Address="ISM",Age=27},
        //    };
        //    context.Set<Student>().AddRange(students);
        //    context.SaveChanges();
        //})
        .UseSeeding((context, _) =>
        {
            if (context.Set<Course>().Any()) return;
            List<Course> courses = new List<Course>()
            {
                new Course {Name="HTML"},
                new Course {Name="CSS"},
                new Course {Name="JS"},
                new Course {Name="C#"},
            };
            context.Set<Course>().AddRange(courses);
            context.SaveChanges();
        })
        .UseSeeding((context, _) =>
        {
            if (context.Set<Department>().Any()) return;
            List<Department> departments = new List<Department>()
            {
                new Department {Name="AI"},
                new Department {Name="SD"},
                new Department {Name="UI"},
            };
            context.Set<Department>().AddRange(departments);
            context.SaveChanges();
        })
        .UseSqlServer(configuration.GetConnectionString("dev")));
    }
}
