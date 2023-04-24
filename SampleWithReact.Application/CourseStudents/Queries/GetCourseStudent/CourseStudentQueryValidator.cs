using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SampleWithReact.Application.Common.Constants;

namespace SampleWithReact.Application.CourseStudents.Queries.GetCourseStudent
{
    public class CourseStudentQueryValidator:AbstractValidator<CourseStudentQuery>
    {
        public CourseStudentQueryValidator()
        {
            RuleFor(x => x.Page)
                .NotEmpty()
                .GreaterThanOrEqualTo(QueryConstants.MinPage);
            RuleFor(x => x.Size)
                .NotEmpty()
                .GreaterThanOrEqualTo(QueryConstants.MinSize)
                .LessThanOrEqualTo(QueryConstants.MaxSize);
        }
    }
}
