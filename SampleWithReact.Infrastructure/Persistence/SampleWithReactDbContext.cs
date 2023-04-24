using Microsoft.EntityFrameworkCore;
using SampleWithReact.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWithReact.Infrastructure.Persistence
{
    public class SampleWithReactDbContext : DbContext
    {
        public const string Connection = "PostgreSQLConnection";

        public SampleWithReactDbContext(DbContextOptions<SampleWithReactDbContext> options) : base(options)
        {
        }

        public DbSet<CourseEntity> CourseEntities { get; set; }
        public DbSet<StudentEntity> StudentEntities { get; set; }
        public DbSet<CourseStudentEntity> CourseStudents { get; set; }
        public DbSet<LecturerEntity> LecturerEntities { get; set; }
    }
}
