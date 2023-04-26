using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWithReact.Application.Lecturers.Commands.DeleteLecturers
{
    public class DeleteLecturerCommandValidator : AbstractValidator<DeleteLecturerCommand>
    {
        public DeleteLecturerCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
