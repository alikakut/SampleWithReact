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

namespace SampleWithReact.Application.CourseStudents.Commands.CreateCourseStudent
{
     public class CreateCourseStudentCommandHandler:IRequestHandler<CreateCourseStudentCommand,ErrorOr<CourseStudentEntity>>
    {
        private readonly ICourseStudentRepository _courseStudentRepository;
        public CreateCourseStudentCommandHandler(ICourseStudentRepository courseStudentRepository)
        {
            _courseStudentRepository = courseStudentRepository;
        }

        public async Task<ErrorOr<CourseStudentEntity>> Handle(CreateCourseStudentCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var courseStudentEntity = new CourseStudentEntity
            {
                
            };
            var persistenceResult = _courseStudentRepository.Add(courseStudentEntity);
            if (persistenceResult is null || persistenceResult.Id < 1)
            {
                return Errors.DbPersistence;
            }
            return persistenceResult;
        }
    }
}
