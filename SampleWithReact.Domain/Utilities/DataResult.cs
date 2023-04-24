using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWithReact.Domain.Utilities
{
    public class DataResult
    {
        public bool IsSuccess { get; set; } = false;
        public long PkId { get; set; }
        public List<string> ErrorMessages { get; set; } = new List<string> { };
        public string ErrorMessage { get; set; }
    }
}
