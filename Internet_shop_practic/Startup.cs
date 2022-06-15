using Internet_shop_practic.interfaces;
using Internet_shop_practic.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
namespace Internet_shop_practic
{
    /// <summary>
    /// Класс, роизводящий конфигурацию приложения и настраивающий сервисы 
    /// </summary>
    public class Startup
    {
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment HostingEnvironment { get; private set; }
        public IConfiguration Configuration { get; private set; }

        /// <summary>
        /// Подключения конфигурационного файла "appsetings.json"
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="env"></param>
        public Startup(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            this.HostingEnvironment = env;
            this.Configuration = (new ConfigurationBuilder()).AddJsonFile("appsettings.json").Build();
        }
         
        /// <summary>
        /// Регистрация сервисов и зависимостей
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void ConfigureServices(IServiceCollection services)
        {          
            services.AddTransient<IGetProducts, GetProducts>();
            services.AddTransient<IGetCustomers, GetCustomers>();

            services.AddDbContext<DBmodel>();
            
            services.AddMvc();
        }
        
        /// <summary>
        /// Конфигурация приложения и подключение сервисов
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (DBmodel db = new DBmodel(Configuration))
            {
                db.SaveChanges();
            }

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
   
            });          
        }        
    }
}
