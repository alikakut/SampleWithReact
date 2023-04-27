using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using MediatR;
using SampleWithReact.Application.Common.Interfaces.Persistence;
using SampleWithReact.Domain.Errors;

namespace SampleWithReact.Application.Courses.Queries.GetCourses
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

            if (_courseRepository.Get(request.Page,request.Size) is not { } courseList)
            {
                return Errors.NotFound;
            }

            int totalRowCount = _courseRepository.Count();
            int totalPageCount = (int)Math.Ceiling(totalRowCount / (float)request.Size);

            return new CourseQueryResult(
                request.Page,
                request.Size,
                totalPageCount,
                totalRowCount,
                courseList);
        }
    }
}
