using ApiRestAspNet5_01.Hypermedia.Enricher;
using ApiRestAspNet5_01.Hypermedia.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace ApiRestAspNet5_01.Configurations
{
    public static class DependencyInjectionHateoas
    {
        public static IServiceCollection AddInfrastructureHateoas(this IServiceCollection services)
        {
            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ContentResponseEnricherList.Add(new PersonEnricher());
            services.AddSingleton(filterOptions);

            //var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ContentResponseEnricherList.Add(new BookEnricher());
            services.AddSingleton(filterOptions);

            return services;
        }
    }
}
