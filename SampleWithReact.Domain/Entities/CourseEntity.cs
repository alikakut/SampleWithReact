using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleWithReact.Domain.Entities.Commnon;

namespace SampleWithReact.Domain.Entities
{
    [Table("course")]
    public class CourseEntity:BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }
    }
}
