using SampleWithReact.Application.Common.Interfaces.Persistence;
using SampleWithReact.Domain.Entities;
using SampleWithReact.Infrastructure.Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWithReact.Infrastructure.Persistence.Repositories
{
    public class CourseRepository : EFRepositoryBase<CourseEntity>, ICourseRepository
    {
        public CourseRepository(SampleWithReactDbContext context) : base(context)
        {
        }
    }
}
