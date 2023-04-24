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

namespace SampleWithReact.Application.Students.Commands.UpdateStudents
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, ErrorOr<StudentEntity>>
    {
        private readonly IStudentRepository _studentRepository;
        public UpdateStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<ErrorOr<StudentEntity>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var student = _studentRepository.GetById(request.Id);
            if (student == null)
            {
                return Errors.NotFound;
            }

            student.FirstName = request.FirstName;
            student.MiddleName = request.MiddleName;
            student.LastName = request.LastName;
            
           var updateResult= _studentRepository.Update(student);
            if (updateResult == null)
            {
                return Errors.NotFound;
            }
            return updateResult;
        }
    }
}
