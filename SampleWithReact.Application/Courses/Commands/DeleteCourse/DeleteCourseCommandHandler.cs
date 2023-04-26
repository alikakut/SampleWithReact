using ErrorOr;
using MediatR;
using SampleWithReact.Application.Common.Interfaces.Persistence;
using SampleWithReact.Application.Students.Commands.DeleteStudents;
using SampleWithReact.Domain.Entities;
using SampleWithReact.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWithReact.Application.Courses.Commands.DeleteCourse
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, ErrorOr<CourseEntity>>
    {
        private readonly ICourseRepository _courseRepository;

        public DeleteCourseCommandHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<ErrorOr<CourseEntity>> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var course = _courseRepository.GetById(request.Id);

            if (course == null || course.Id < 1)
            {
                return Errors.NotFound;
            }

            var deleteResult = _courseRepository.Delete(course);

            if (deleteResult == null)
            {
                return Errors.NotFound;
            }

            return deleteResult;
        }
    }
}
