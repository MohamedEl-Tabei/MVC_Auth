using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI_API_DAL;

public class RepoCourse : Repository<Course>, IRepoCourse
{
    public RepoCourse(ITIContext context) : base(context) { }
    
}
