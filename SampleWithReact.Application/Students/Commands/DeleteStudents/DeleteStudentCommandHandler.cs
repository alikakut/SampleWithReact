using ErrorOr;
using MediatR;
using SampleWithReact.Application.Common.Interfaces.Persistence;
using SampleWithReact.Domain.Entities;
using SampleWithReact.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWithReact.Application.Students.Commands.DeleteStudents
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, ErrorOr<StudentEntity>>
    {
        private readonly IStudentRepository _studentRepository;
        public DeleteStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<ErrorOr<StudentEntity>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var student = _studentRepository.GetById(request.Id);
           
            if (student == null)
            {
                return Errors.NotFound;
            }

            var deleteResult = _studentRepository.Delete(student);

            if(deleteResult == null)
            {
                return Errors.NotFound;
            }

            return deleteResult;
        }
    }
}
