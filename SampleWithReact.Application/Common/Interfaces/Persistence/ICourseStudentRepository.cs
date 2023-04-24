using SampleWithReact.Application.Common.Interfaces.Persistence.Common;
using SampleWithReact.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWithReact.Application.Common.Interfaces.Persistence
{
    public interface ICourseStudentRepository:IRepositoryBase<CourseStudentEntity>
    {
    }
}
