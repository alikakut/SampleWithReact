using ErrorOr;
using MediatR;
using SampleWithReact.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWithReact.Application.Courses.Queries.GetByIdCourses
{
    public record CourseGetByIdQuery : BaseQuery, IRequest<ErrorOr<CourseGetByIdQueryResult>>;

}
