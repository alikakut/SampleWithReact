using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
using MediatR;
using SampleWithReact.Application.Common.Models;

namespace SampleWithReact.Application.Students.Queries.GetStudents
{
    public record StudentQuery : BaseQuery, IRequest<ErrorOr<StudentQueryResult>>;
}
