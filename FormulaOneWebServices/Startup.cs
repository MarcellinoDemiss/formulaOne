using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FormulaOneWebServices
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Country:\n");
                    await context.Response.WriteAsync("/api/country\t\t\t//Restituisce la lista delle Countries\n");
                    await context.Response.WriteAsync("/api/country/[sigla nazione]\t//Restituisce una Country in base alla sigla in input\n");
                    await context.Response.WriteAsync("\nDriver:\n");
                    await context.Response.WriteAsync("/api/driver\t\t//Restituisce la lista dei Drivers\n");
                    await context.Response.WriteAsync("/api/driver/id/[id]\t//Restituisce un Driver in base all'id in input\n");
                    await context.Response.WriteAsync("/api/driver/name/[name]\t//Restituisce un Driver in base a nome e cognome in input\n");          
                    await context.Response.WriteAsync("\nTeam:\n");
                    await context.Response.WriteAsync("/api/team\t\t//Restituisce la lista dei Teams\n");
                    await context.Response.WriteAsync("/api/team/id/[id]\t//Restituisce un Team in base all'id in input\n");
                    await context.Response.WriteAsync("/api/team/name/[name]\t//Restituisce un Team in base al nome in input\n");                 
                    await context.Response.WriteAsync("\nDTO:\n");
                    await context.Response.WriteAsync("/api/driverPage\t\t\t//Restituisce le informazioni situate nella pagina 'Drivers' di formula1.com\n");
                    await context.Response.WriteAsync("/api/driverPage/number/[number]\t//Restituisce i dettagli quando clicchi su un singolo Driver\n");
                    await context.Response.WriteAsync("/api/teamPage\t\t\t//Restituisce le informazioni situate nella pagina 'Teams' di formula1.com\n");
                    await context.Response.WriteAsync("/api/teamPage/id/[id]\t\t//Restituisce i dettagli quando clicchi su un singolo Team\n");
                });
                endpoints.MapControllers();
            });
        }
    }
}
