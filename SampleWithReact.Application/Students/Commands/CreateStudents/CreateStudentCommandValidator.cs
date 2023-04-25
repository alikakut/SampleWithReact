using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace SampleWithReact.Application.Students.Commands.CreateStudents
{
    public class CreateStudentCommandValidator:AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator()
        {
            
        }
    }
}
