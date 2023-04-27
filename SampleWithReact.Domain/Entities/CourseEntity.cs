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

        [Column("course_name")]
        public string CourseName { get; set; }

        [Column("status")]
        public int Status { get; set; }

        [Column("lecturer_id")]
        public long LecturerId { get; set; }

        [Column("is_active")]
        public bool IsActive { get; set; }

        [Column("created_date_time")]
        public DateTime CreateDateTime { get; set; }

        //[ForeignKey("course_student_id")]
        //public CourseStudentEntity courseStudent { get; set;}

        [ForeignKey("LecturerId")]
        public LecturerEntity Lecturer { get; set; }
    }
}
