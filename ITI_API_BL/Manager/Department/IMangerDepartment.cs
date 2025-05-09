using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI_API_DAL;
using ITI_API_DAL.Models;

namespace ITI_API_BL.Manager;

public interface IMangerDepartment
{
    List<Department> GetAll();

}
