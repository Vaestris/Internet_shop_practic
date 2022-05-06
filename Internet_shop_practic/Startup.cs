using Internet_shop_practic.interfaces;
using Internet_shop_practic.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Internet_shop_practic
{
    /// <summary>
    /// �����, ����������� ������������ ���������� � ������������� ������� 
    /// </summary>
    public class Startup
    {     
        /// <summary>
        /// ������������ �������, ������� ������������ �����������.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<DBmodel>();
            services.AddTransient<IGetProducts, GetProducts>();
            services.AddTransient<IGetCustomers, GetCustomers>();

            services.AddMvc();
        }

        /// <summary>
        /// �������������, ��� ���������� ����� ������������ ������.
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
