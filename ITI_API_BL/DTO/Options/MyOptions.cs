using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI_API_BL.DTO;

public class MyOptions
{
    public const string key = "MyOptions";
    public bool Required { get; set; }
    public int MaxLength { get; set; }
    public int MinLength { get; set; }
}
