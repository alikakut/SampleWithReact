using SampleWithReact.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWithReact.Application.CourseStudents.Queries.GetByIdCourseStudent
{
    public record CourseStudentQueryGetByIdResult
    (long Id, string CourseStudentName, long CourseId, long StudentId,int Grade,bool IsDeleted);
    
}
