using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using MediatR;
using SampleWithReact.Domain.Entities;

namespace SampleWithReact.Application.Courses.Commands.CreateCourse
{
    public record CreateCourseCommand(
    string Name, int Status, long LecturerId, bool IsActive) : IRequest<ErrorOr<CourseEntity>>;
}
