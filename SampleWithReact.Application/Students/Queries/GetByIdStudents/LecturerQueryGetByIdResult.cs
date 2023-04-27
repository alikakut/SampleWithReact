using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWithReact.Application.Students.Queries.GetByIdStudents
{
    public record StudentQueryGetByIdResult
    (
        long Id,string FirstName,string MiddleName, string LastName, bool IsActive, bool IsDelete
    );
}
