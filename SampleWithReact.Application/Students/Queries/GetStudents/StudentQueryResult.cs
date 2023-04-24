using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleWithReact.Domain.Entities;

namespace SampleWithReact.Application.Students.Queries.GetStudents
{
    public record StudentQueryResult (int CurrentPage,
    int PageSize,
    int TotalPageCount,
    int TotalRowCount,
    List<StudentEntity> Data);
}
