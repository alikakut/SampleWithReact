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
    public class StudentRepository : EFRepositoryBase<StudentEntity>, IStudentRepository
    {
        public StudentRepository(SampleWithReactDbContext context) : base(context)
        {
        }
    }
}
