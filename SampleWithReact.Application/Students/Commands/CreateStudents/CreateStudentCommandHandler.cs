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

namespace SampleWithReact.Application.Students.Commands.CreateStudents
{
    public class CreateStudentCommandHandler:IRequestHandler<CreateStudentCommand,ErrorOr<StudentEntity>>
    {
        private readonly IStudentRepository _studentRepository;
        public CreateStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<ErrorOr<StudentEntity>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var studentEntity = new StudentEntity
            {
                FirstName = request.FirstName,
                MiddleName=request.MiddleName,
                LastName=request.LastName,
           
            };
            var persistenceResult = _studentRepository.Add(studentEntity);
            if (persistenceResult is null || persistenceResult.Id < 1)
            {
                return Errors.DbPersistence;
            }
            return persistenceResult;
        }
    }
}
