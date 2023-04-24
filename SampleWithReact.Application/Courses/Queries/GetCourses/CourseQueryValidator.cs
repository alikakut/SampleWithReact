using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SampleWithReact.Application.Common.Constants;

namespace SampleWithReact.Application.Courses.Queries.GetCourses
{
    public class CourseQueryValidator : AbstractValidator<CourseQuery>
    {
        public CourseQueryValidator()
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
