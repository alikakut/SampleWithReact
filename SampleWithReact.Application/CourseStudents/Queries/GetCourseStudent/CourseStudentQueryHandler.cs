using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using MediatR;
using SampleWithReact.Application.Common.Interfaces.Persistence;
using SampleWithReact.Application.Courses.Queries.GetCourses;
using SampleWithReact.Application.Students.Queries.GetStudents;
using SampleWithReact.Domain.Errors;

namespace SampleWithReact.Application.CourseStudents.Queries.GetCourseStudent
{
    public class CourseStudentQueryHandler : IRequestHandler<CourseStudentQuery, ErrorOr<CourseStudentQueryResult>>
    {
        private readonly ICourseStudentRepository _courseStudentRepository;
        public CourseStudentQueryHandler(ICourseStudentRepository courseStudentRepository)
        {
            _courseStudentRepository = courseStudentRepository;
        }

        public async Task<ErrorOr<CourseStudentQueryResult>> Handle(CourseStudentQuery request, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            await Task.CompletedTask;

            if (_courseStudentRepository.GetAll() is not { } courseStudentList)
            {
                return Errors.NotFound;
            }

            int totalRowCount = _courseStudentRepository.Count();
            int totalPageCount = (int)Math.Ceiling(totalRowCount / (float)request.Size);

            return new CourseStudentQueryResult();
        }
    }
}
