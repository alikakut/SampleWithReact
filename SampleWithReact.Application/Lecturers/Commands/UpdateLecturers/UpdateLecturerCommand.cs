using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using MediatR;
using SampleWithReact.Domain.Entities;

namespace SampleWithReact.Application.Lecturers.Commands.UpdateLecturers
{
    public record UpdateLecturerCommand(int Id, string LastName, string FirstName) : IRequest<ErrorOr<LecturerEntity>>;
}
