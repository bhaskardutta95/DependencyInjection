using Microsoft.Extensions.DependencyInjection;

namespace Service
{
    public static class Configuration
    {
        public static IServiceCollection ServiceDependency(this IServiceCollection services)
        {
            services.AddScoped<IScoped, DIService>();
            services.AddTransient<ITransient, DIService>();
            services.AddSingleton<ISingleton, DIService>();

            return services;
        }
    }
}
