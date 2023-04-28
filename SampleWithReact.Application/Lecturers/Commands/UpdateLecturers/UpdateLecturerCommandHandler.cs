using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using FluentValidation;
using MediatR;
using SampleWithReact.Application.Common.Interfaces.Persistence;
using SampleWithReact.Domain.Entities;
using SampleWithReact.Domain.Errors;

namespace SampleWithReact.Application.Lecturers.Commands.UpdateLecturers
{
    public class UpdateLecturerCommandHandler : IRequestHandler<UpdateLecturerCommand, ErrorOr<LecturerEntity>>
    {
        private readonly ILecturerRepository _lecturerRepository;
        public UpdateLecturerCommandHandler(ILecturerRepository lecturerRepository)
        {
            _lecturerRepository = lecturerRepository;
        }
        public async Task<ErrorOr<LecturerEntity>> Handle(UpdateLecturerCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var student = _lecturerRepository.GetById(request.Id);
            if (student == null || student.Id < 1)
            {
                return Errors.NotFound;
            }
            student.FirstName = request.FirstName;
            student.LastName = request.LastName;
            var updateResult = _lecturerRepository.Update(student);
            if (updateResult == null)
            {
                return Errors.NotFound;
            }
            return updateResult;
        }
    }
}
