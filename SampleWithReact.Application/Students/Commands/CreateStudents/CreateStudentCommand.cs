using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using MediatR;
using SampleWithReact.Domain.Entities;

namespace SampleWithReact.Application.Students.Commands.CreateStudents
{
    public record CreateStudentCommand(
    string FirstName, string MiddleName, string LastName) : IRequest<ErrorOr<StudentEntity>>;

}
