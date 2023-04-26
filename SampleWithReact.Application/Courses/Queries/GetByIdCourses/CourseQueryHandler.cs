using ErrorOr;
using MediatR;
using SampleWithReact.Application.Common.Interfaces.Persistence;
using SampleWithReact.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWithReact.Application.Courses.Queries.GetByIdCourses
{
    public class CourseQueryHandler : IRequestHandler<CourseQuery, ErrorOr<CourseQueryResult>>
    {
        private readonly ICourseRepository _courseRepository;

        public CourseQueryHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<ErrorOr<CourseQueryResult>> Handle(CourseQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (request.Id <= 0)
            {
                return Errors.NotFound;
            }

            var course = _courseRepository.GetById(request.Id);

            if (course == null)
            {
                return Errors.NotFound;
            }
            return new CourseQueryResult();
        }
    }
}
