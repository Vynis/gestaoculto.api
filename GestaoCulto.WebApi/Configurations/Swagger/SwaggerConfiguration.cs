using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace GestaoCulto.WebApi.Configurations.Swagger
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Gestao Culto Api",
                    Version = "v1",
                    Description = "API para fornecer serviços",
                    Contact = new OpenApiContact()
                    {
                        Name = "Gestao Culto Api"
                    }
                });
                c.TagActionsBy(api => api.GroupBySwaggerGroupAttribute());
            });


        }
        public static void ConfigSwaggerApp(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.DocExpansion(DocExpansion.None);
                s.SwaggerEndpoint("../swagger/v1/swagger.json", "Gestao Culto Api API V1.0");
                s.DocumentTitle = "Gestao Culto Api";
            });
        }

    }
}
