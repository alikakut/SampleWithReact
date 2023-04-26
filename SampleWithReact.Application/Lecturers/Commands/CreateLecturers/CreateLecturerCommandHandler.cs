using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using MediatR;
using SampleWithReact.Application.Common.Interfaces.Persistence;
using SampleWithReact.Application.Students.Commands.CreateStudents;
using SampleWithReact.Domain.Entities;
using SampleWithReact.Domain.Errors;

namespace SampleWithReact.Application.Lecturers.Commands.CreateLecturers
{
    public class CreateLecturerCommandHandler : IRequestHandler<CreateLecturerCommand, ErrorOr<LecturerEntity>>
    {
        private readonly ILecturerRepository _lecturerRepository;
        public CreateLecturerCommandHandler(ILecturerRepository lecturerRepository)
        {
            _lecturerRepository = lecturerRepository;
        }

        public async Task<ErrorOr<LecturerEntity>> Handle(CreateLecturerCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var lecturerEntity = new LecturerEntity
            {
                Id=request.Id,
                FirstName = request.FirstName,
                LastName=request.LastName
            };
            var persistenceResult = _lecturerRepository.Add(lecturerEntity);
            if (persistenceResult is null || persistenceResult.Id < 1)
            {
                return Errors.DbPersistence;
            }
            return persistenceResult;
        }
    }
}
