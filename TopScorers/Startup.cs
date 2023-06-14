using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TopScorers.CSVReader;
using TopScorers.Calculations;

namespace TopScorers
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add GraphQL services
            services.AddGraphQLServer()
            .AddQueryType<QueryType>();


            // Add services
            services.AddSingleton<ICSVParser, CSVParser>();
            services.AddSingleton<ITopScorerCalculator, TopScorerCalculator>();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhost:3000")
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            // Use GraphQL middleware
            app.UseCors();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });

            app.UsePlayground();
        }
    }
}
