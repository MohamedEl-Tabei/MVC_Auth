using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI_API_DAL.Models;

public class Department
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public List<Student> Students { get;set; }
}
