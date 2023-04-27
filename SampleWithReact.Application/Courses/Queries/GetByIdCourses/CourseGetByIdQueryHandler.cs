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
    public class CourseGetByIdQueryHandler : IRequestHandler<CourseGetByIdQuery, ErrorOr<CourseGetByIdQueryResult>>
    {
        private readonly ICourseRepository _courseRepository;

        public CourseGetByIdQueryHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<ErrorOr<CourseGetByIdQueryResult>> Handle(CourseGetByIdQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var course = _courseRepository.GetById(request.Id);

            if (course == null || course.Id <1)
            {
                return Errors.NotFound;
            }
            return new CourseGetByIdQueryResult( request.Id, course.CourseName, course.Status, course.LecturerId, course.IsDeleted , course.IsActive);
        }
    }
}
