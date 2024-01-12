using APITubefetch.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace APITubefetch
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //Injeção de dependência
            //Adicionando Controllers 
            services.AddControllers();

            //Adicionando Databases
            services.AddDbContext<AppDbContext>();

            //Cors
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder => builder.WithOrigins("http://127.0.0.1:4200")
                .AllowAnyMethod()
                .AllowAnyHeader()
                );
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors("AllowSpecificOrigin");

            app.UseEndpoints(endpoints =>
            {
                //Mapeando rotas iniciais
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
