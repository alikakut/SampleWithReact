using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleWithReact.Domain.Entities.Commnon;

namespace SampleWithReact.Domain.Entities
{
    [Table("course_student")]
    public class CourseStudentEntity:BaseEntity
    {
        [Column("course_student_name")]
        public string CourseStudentName { get; set; }    

        [Column("course_id")]
        public long CourseId { get; set; }

        [Column("student_id")]
        public long StudentId { get; set; }

        [Column("grade")]
        public int Grade { get; set; }

        [ForeignKey("CourseId")]
        public CourseEntity Course { get; set; }

        [ForeignKey("StudentId")]
        public StudentEntity Student { get; set; }
    }
}
