﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleWithReact.Domain.Entities;

namespace SampleWithReact.Application.CourseStudents.Queries.GetCourseStudent
{
    //public record CourseStudentQueryResult(int CurrentPage,
    //int PageSize,
    //int TotalPageCount,
    //int TotalRowCount,
    //List<CourseStudentEntity> Data);
    public class CourseStudentQueryResult
    {
        int CourseId;
        int CourseName;
    }
}
