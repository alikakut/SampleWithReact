using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWithReact.Application.Common.Models;
public record BaseQuery()
{     
    public int Page { get; set; }
    public int Size { get; set; }
    public int Id { get; set; }
}
