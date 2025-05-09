using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI_API_DAL.Models;

namespace ITI_API_DAL;

public class RepoDepartment:Repository<Department>,IDepartmentRepo
{
    public RepoDepartment(ITIContext context) : base(context) { }

}
