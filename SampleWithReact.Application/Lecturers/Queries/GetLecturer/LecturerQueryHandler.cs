using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using MediatR;
using SampleWithReact.Application.Common.Interfaces.Persistence;
using SampleWithReact.Application.Students.Queries.GetStudents;
using SampleWithReact.Domain.Errors;

namespace SampleWithReact.Application.Lecturers.Queries.GetLecturer
{
    public class LecturerQueryHandler : IRequestHandler<LecturerQuery, ErrorOr<LecturerQueryResult>>
    {
        private readonly ILecturerRepository _lecturerRepository;
        public LecturerQueryHandler(ILecturerRepository lecturerRepository)
        {
            _lecturerRepository = lecturerRepository;
        }

        public async Task<ErrorOr<LecturerQueryResult>> Handle(LecturerQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            if (_lecturerRepository.Get(request.Page, request.Size) is not { } lecturerList)
            {
                return Errors.NotFound;
            }

            int totalRowCount = _lecturerRepository.Count();
            int totalPageCount = (int)Math.Ceiling(totalRowCount / (float)request.Size);

            return new LecturerQueryResult(
                request.Page,
            request.Size,
            totalPageCount,
            totalRowCount,
            lecturerList);
        }
    }
}
