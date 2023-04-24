using Microsoft.AspNetCore.Mvc.Infrastructure;
using SampleWithReact.Api.Common.Errors;
using SampleWithReact.Api.Common.Mapping;

namespace SampleWithReact.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSingleton<ProblemDetailsFactory, SampleWithReactApiProblemDetailsFactory>();
            services.AddMappings();

            return services;
        }
    }
}
