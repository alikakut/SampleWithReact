using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using MediatR;
using SampleWithReact.Domain.Entities;

namespace SampleWithReact.Application.Lecturers.Commands.CreateLecturers
{
    public record CreateLecturerCommand(
    string FirstName, string LastName) : IRequest<ErrorOr<LecturerEntity>>;
}
