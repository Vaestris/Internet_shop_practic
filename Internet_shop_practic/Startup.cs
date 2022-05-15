using Internet_shop_practic.interfaces;
using Internet_shop_practic.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace Internet_shop_practic
{
    /// <summary>
    ///  ласс, роизвод€щий конфигурацию приложени€ и настраивающий сервисы 
    /// </summary>
    public class Startup
    {

        public Microsoft.AspNetCore.Hosting.IHostingEnvironment HostingEnvironment { get; private set; }
        public IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            this.HostingEnvironment = env;
            this.Configuration = configuration;
        }
         




        /// <summary>
        /// –егистрирует сервисы, которые используютс€ приложением.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<DBmodel>();//(options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionStrings:DefaultConnection")));
            services.AddTransient<IGetProducts, GetProducts>();
            services.AddTransient<IGetCustomers, GetCustomers>();
           
            services.AddMvc();
        }
        
            
        


        /// <summary>
        /// ”станавливает, как приложение будет обрабатывать запрос.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                app.UseStaticFiles();
                
            }

            app.UseRouting();
          


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}");

                endpoints.MapControllerRoute(
               name: "default",
               pattern: "{controller=Home}/{action=ProductList}");

                endpoints.MapControllerRoute(
               name: "default",
               pattern: "{controller=Home}/{action=PIndex}");

                
            });
        }
        
    }
}
