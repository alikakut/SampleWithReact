using AutoMapper;
using ErrorOr;
using MediatR;
using SampleWithReact.Application.Common.Interfaces.Persistence;

using SampleWithReact.Domain.Errors;

namespace SampleWithReact.Application.Students.Queries.GetByIdStudents
{
    public class StudentQueryGetByIdHandler : IRequestHandler<StudentGetByIdQuery, ErrorOr<StudentQueryGetByIdResult>>
    {
        IStudentRepository _studentRepository;
     
        public StudentQueryGetByIdHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
            
        }
        public async Task<ErrorOr<StudentQueryGetByIdResult>> Handle(StudentGetByIdQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var student = _studentRepository.GetById(query.Id);

            if (student == null || student.Id >= 1)
            {
                return Errors.NotFound;
            }
            return new StudentQueryGetByIdResult(query.Id,student.FirstName,student.MiddleName,student.LastName,student.IsDeleted, student.IsActive);
               
        }
    }
}
