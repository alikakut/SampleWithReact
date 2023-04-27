using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWithReact.Application.Courses.Queries.GetByIdCourses
{
    public record CourseGetByIdQueryResult
    
       ( long Id, string CourseName, int Status,long LecturerId,bool IsDeleted, bool IsActive);
   
}
