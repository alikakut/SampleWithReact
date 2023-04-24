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

namespace SampleWithReact.Application.Students.Queries.GetStudents
{
    public class StudentQueryHandler:IRequestHandler<StudentQuery,ErrorOr<StudentQueryResult>>
    {
        private readonly IStudentRepository _studentRepository;
        public StudentQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<ErrorOr<StudentQueryResult>> Handle(StudentQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (_studentRepository.Get(request.Page, request.Size) is not { } studentList)
            {
                return Errors.NotFound;
            }

            int totalRowCount = _studentRepository.Count();
            int totalPageCount = (int)Math.Ceiling(totalRowCount / (float)request.Size);

            return new StudentQueryResult(
                request.Page,
            request.Size,
            totalPageCount,
            totalRowCount,
            studentList);
        }
    }
}
