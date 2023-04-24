using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleWithReact.Domain.Entities;

namespace SampleWithReact.Application.Lecturers.Queries.GetLecturer
{
    public record LecturerQueryResult(int CurrentPage,
    int PageSize,
    int TotalPageCount,
    int TotalRowCount,
    List<LecturerEntity> Data);

}
