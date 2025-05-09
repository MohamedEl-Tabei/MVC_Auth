using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI_API_DAL;

namespace ITI_API_BL;

public interface IManagerCourse
{
    List<Course> GetAll();

}
