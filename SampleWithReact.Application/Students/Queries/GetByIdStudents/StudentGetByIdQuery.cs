using ErrorOr;
using MediatR;
using SampleWithReact.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWithReact.Application.Students.Queries.GetByIdStudents
{
    public record StudentGetByIdQuery : BaseQuery, IRequest<ErrorOr<StudentQueryGetByIdResult>>;
  
} 