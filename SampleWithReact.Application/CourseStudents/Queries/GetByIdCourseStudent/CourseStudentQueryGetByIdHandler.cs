using ErrorOr;
using MediatR;
using SampleWithReact.Application.Common.Interfaces.Persistence;
using SampleWithReact.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWithReact.Application.CourseStudents.Queries.GetByIdCourseStudent
{
    public class CourseStudentQueryGetByIdHandler : IRequestHandler<CourseStudentGetByIdQuery, ErrorOr<CourseStudentQueryGetByIdResult>>
    {
        private readonly ICourseStudentRepository _courseStudentRepository;

        public CourseStudentQueryGetByIdHandler(ICourseStudentRepository courseStudentRepository)
        {
            _courseStudentRepository = courseStudentRepository;
        }

        public async Task<ErrorOr<CourseStudentQueryGetByIdResult>> Handle(CourseStudentGetByIdQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var courseStudent = _courseStudentRepository.GetById(request.Id);

            if (courseStudent == null || courseStudent.Id <1)
            {
                return Errors.NotFound;
            }
            return new CourseStudentQueryGetByIdResult(request.Id, courseStudent.Name, courseStudent.CourseId, courseStudent.StudentId, courseStudent.Grade, courseStudent.IsDeleted);
        }
    }
}
