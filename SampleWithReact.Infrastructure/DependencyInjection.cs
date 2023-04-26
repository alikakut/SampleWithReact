 using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SampleWithReact.Application.Common.Interfaces.Persistence;
using SampleWithReact.Infrastructure.Persistence;
using SampleWithReact.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWithReact.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
         this IServiceCollection services,
         ConfigurationManager configuration)
        {
            services
                .AddPersistence(configuration);

            return services;
        }

        private static IServiceCollection AddPersistence(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services.AddDbContext<SampleWithReactDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString(
                        SampleWithReactDbContext.Connection)));


            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ILecturerRepository, LecturerRepository>();
            services.AddScoped<ICourseStudentRepository, CourseStudentRepository>();


            return services;
        }
    }
}