using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace SampleWithReact.Application.Lecturers.Commands.CreateLecturers
{
    public class CreateLecturerCommandValidator:AbstractValidator<CreateLecturerCommand>
    {
        public CreateLecturerCommandValidator()
        {
            //RuleFor(x => x.CourseName).NotEmpty();
        }
    }
}
