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

namespace SampleWithReact.Application.CourseStudents.Commands.DeleteCourseStudents
{
    public class DeleteCourseStudentCommandHandler : IRequestHandler<DeleteCourseStudentCommand, ErrorOr<CourseStudentEntity>>
    {
        private readonly ICourseStudentRepository _courseStudentRepository;

        public DeleteCourseStudentCommandHandler(ICourseStudentRepository courseStudentRepository)
        {
            _courseStudentRepository = courseStudentRepository;
        }

        public async Task<ErrorOr<CourseStudentEntity>> Handle(DeleteCourseStudentCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var courseStudent = _courseStudentRepository.GetById(request.Id);

            if (courseStudent == null || courseStudent.Id < 1)
            {
                return Errors.NotFound;
            }

            var deleteResult = _courseStudentRepository.Delete(courseStudent);

            if (deleteResult == null)
            {
                return Errors.NotFound;
            }

            return deleteResult;
        }
    }
}
