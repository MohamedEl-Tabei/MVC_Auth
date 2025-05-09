using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI_API_BL.Manager;
using ITI_BL.Manager;
using ITI_BL.Manager.User;
using Microsoft.Extensions.DependencyInjection;

namespace ITI_API_BL;

public static class BL_Extensions
{
    public static void AddBLServices(this IServiceCollection services)
    {
        services.AddScoped<IManagerStudent,MangerStudent>();
        services.AddScoped<IManagerCourse,ManagerCourse>();
        services.AddScoped<IMangerDepartment,ManagerDepartment>();
        services.AddScoped<IUserManager, UserManager>();
    }
}
