using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SampleWithReact.Application.Courses.Commands.CreateCourse;

namespace SampleWithReact.Application.CourseStudents.Commands.CreateCourseStudent
{
    public class CreateCourseStudentCommandValidator : AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseStudentCommandValidator()
        {
            //RuleFor(x => x.).NotEmpty();
        }
    }
}
