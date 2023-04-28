using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using FluentValidation;
using MediatR;
using SampleWithReact.Application.Common.Interfaces.Persistence;
using SampleWithReact.Domain.Entities;
using SampleWithReact.Domain.Errors;

namespace SampleWithReact.Application.Lecturers.Commands.UpdateLecturers
{
    public class UpdateLecturerCommandValidator : AbstractValidator<UpdateLecturerCommand>
    {
        public UpdateLecturerCommandValidator()
        {
        }
    }
}
