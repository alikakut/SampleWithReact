using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace SampleWithReact.Application.Students.Commands.DeleteStudents
{
    public class DeleteStudentCommandValidator : AbstractValidator<DeleteStudentCommand>
    {
        public DeleteStudentCommandValidator()
        {
           // RuleFor(x => x.Id).NotEmpty();
        }
    }
}
