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

        public async Task<ErrorOr<LecturerQueryGetByIdResult>> Handle(LecturerGetByIdQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var lecturer = _lecturerRepository.GetById(query.Id);
            
            if (lecturer == null || lecturer.Id < 1  )
            {
                return Errors.NotFound;
            }
          
            return new LecturerQueryGetByIdResult(query.Id, lecturer.FirstName,lecturer.LastName,lecturer.IsActive,lecturer.IsDeleted);
            
        }
    }
}
