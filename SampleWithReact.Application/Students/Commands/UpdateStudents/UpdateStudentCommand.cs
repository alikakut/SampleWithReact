using ErrorOr;
using MediatR;
using SampleWithReact.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWithReact.Application.Students.Commands.DeleteStudents
{
    public record UpdateStudentCommand(int Id,string MiddleName, string LastName,string FirstName) :IRequest<ErrorOr<StudentEntity>>;
}
