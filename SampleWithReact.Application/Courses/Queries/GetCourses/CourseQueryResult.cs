using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleWithReact.Domain.Entities;

namespace SampleWithReact.Application.Courses.Queries.GetCourses
{
    public record CourseQueryResult(
        int CurrentPage,
    int PageSize,
    int TotalPageCount,
    int TotalRowCount,
    List<CourseEntity> Data);
}
