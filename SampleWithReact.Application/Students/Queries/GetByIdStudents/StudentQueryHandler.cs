using AutoMapper;
using ErrorOr;
using MediatR;
using SampleWithReact.Application.Common.Interfaces.Persistence;
using SampleWithReact.Domain.Errors;

namespace SampleWithReact.Application.Students.Queries.GetByIdStudents
{
    public class StudentQueryHandler : IRequestHandler<StudentQuery, ErrorOr<StudentQueryResult>>
    {
        IStudentRepository _studentRepository;
     
        public StudentQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
            
        }
        public async Task<ErrorOr<StudentQueryResult>> Handle(StudentQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (query.Id <= 0)
            {
                return Errors.NotFound;
            }

            var student = _studentRepository.GetById(query.Id);

            if (_studentRepository.Get(query.Page, query.Size) is not { } studentList)
            {
                return Errors.NotFound;
            }
            int totalRowCount = _studentRepository.Count();
            int totalPageCount = (int)Math.Ceiling(totalRowCount / (float)query.Size);
            return new StudentQueryResult(
                query.Page,
            query.Size,
            totalPageCount,
            totalRowCount,
            studentList);

        }
    }
}
