using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI_API_DAL;
using ITI_API_DAL.Models;

namespace ITI_API_BL.DTO.Student;

public class DTOStudentCreate
{
    [Required]
    [MinLength(3)]
    public string Name { get; set; }
    [Required]
    [MinLength(3)]
    public string Address { get; set; }
    [Required]
    public int Age { get; set; }
    [DisplayName("Select Your Department")]
    public Guid DepartmentId { get; set; }

}
