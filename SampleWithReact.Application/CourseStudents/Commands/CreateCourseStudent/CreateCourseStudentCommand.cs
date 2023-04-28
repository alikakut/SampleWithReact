using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using MediatR;
using SampleWithReact.Domain.Entities;

namespace SampleWithReact.Application.CourseStudents.Commands.CreateCourseStudent
{
    public record CreateCourseStudentCommand(
   long CourseId, long StudentId, int Grade,string Name) : IRequest<ErrorOr<CourseStudentEntity>>;
}
