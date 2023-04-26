using FluentValidation;
using SampleWithReact.Application.Students.Commands.DeleteStudents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWithReact.Application.CourseStudents.Commands.DeleteCourseStudents
{
    public class DeleteCourseStudentCommandValidator : AbstractValidator<DeleteCourseStudentCommand>
    {
        public DeleteCourseStudentCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
