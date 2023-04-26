using SampleWithReact.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWithReact.Application.Students.Queries.GetByIdStudents
{
    public record StudentQueryResult
  (int CurrentPage,
    int PageSize,
    int TotalPageCount,
    int TotalRowCount,
    List<StudentEntity> Data);
}
