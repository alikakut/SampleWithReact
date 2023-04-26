using ErrorOr;
using MediatR;
using SampleWithReact.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWithReact.Application.Lecturers.Queries.GetByIdLecturer
{
    public record LecturerGetByIdQuery : BaseQuery, IRequest<ErrorOr<LecturerQueryGetByIdResult>>; 

}
