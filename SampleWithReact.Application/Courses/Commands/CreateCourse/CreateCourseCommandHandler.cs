using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using MediatR;
using SampleWithReact.Application.Common.Interfaces.Persistence;
using SampleWithReact.Domain.Entities;
using SampleWithReact.Domain.Errors;

namespace SampleWithReact.Application.Courses.Commands.CreateCourse
{
    public class CreateCourseCommandHandler:IRequestHandler<CreateCourseCommand,ErrorOr<CourseEntity>>
    {
        private readonly ICourseRepository _courseRepository;
        public CreateCourseCommandHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<ErrorOr<CourseEntity>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var courseEntity = new CourseEntity
            {
                Name = request.Name,
                CourseName = request.Name,
                Status= request.Status,
                LecturerId = request.LecturerId
                
            };
            var persistenceResult = _courseRepository.Add(courseEntity);
            if (persistenceResult is null || persistenceResult.Id > 1)
            {
                return Errors.DbPersistence;
            }
            else
            {
                return persistenceResult;
            }
        }
    }
}
