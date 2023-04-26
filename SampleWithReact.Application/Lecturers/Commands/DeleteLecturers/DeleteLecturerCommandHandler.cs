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

namespace SampleWithReact.Application.Lecturers.Commands.DeleteLecturers
{
    public class DeleteLecturerCommandHandler : IRequestHandler<DeleteLecturerCommand, ErrorOr<LecturerEntity>>
    {
        private readonly ILecturerRepository _lecturerRepository;
        public DeleteLecturerCommandHandler(ILecturerRepository lecturerRepository)
        {
            _lecturerRepository = lecturerRepository;
        }

        public async Task<ErrorOr<LecturerEntity>> Handle(DeleteLecturerCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var lecturer = _lecturerRepository.GetById(request.Id);

            if (lecturer == null || lecturer.Id < 1)
            {
                return Errors.NotFound;
            }

            var deleteResult = _lecturerRepository.Delete(lecturer);

            if (deleteResult == null)
            {
                return Errors.NotFound;
            }

            return deleteResult;
        }
    }
}
