using ErrorOr;
using MediatR;
using SampleWithReact.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWithReact.Application.Courses.Commands.DeleteCourse
{
    public record DeleteCourseCommand(int Id) : IRequest<ErrorOr<CourseEntity>>;
    
}
