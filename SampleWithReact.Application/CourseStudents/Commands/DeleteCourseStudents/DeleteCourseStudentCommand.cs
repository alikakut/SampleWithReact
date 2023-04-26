using ErrorOr;
using MediatR;
using SampleWithReact.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWithReact.Application.CourseStudents.Commands.DeleteCourseStudents
{
    public record DeleteCourseStudentCommand(int Id) : IRequest<ErrorOr<CourseStudentEntity>>;

}
