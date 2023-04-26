using ErrorOr;
using MediatR;
using SampleWithReact.Application.Common.Interfaces.Persistence;
using SampleWithReact.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SampleWithReact.Application.Lecturers.Queries.GetByIdLecturer
{
    public class LecturerQueryGetByIdHandler : IRequestHandler<LecturerGetByIdQuery, ErrorOr<LecturerQueryGetByIdResult>>
    {
        private readonly ILecturerRepository _lecturerRepository;

        public LecturerQueryGetByIdHandler(ILecturerRepository lecturerRepository)
        {
            _lecturerRepository = lecturerRepository;
        }

        public async Task<ErrorOr<LecturerQueryGetByIdResult>> Handle(LecturerGetByIdQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (request.Id <= 0)
            {
                return Errors.NotFound;
            }

            var lecturer = _lecturerRepository.GetById(request.Id);

            if (lecturer == null)
            {
                return Errors.NotFound;
            }
            return new LecturerQueryGetByIdResult();


        }
    }
}
