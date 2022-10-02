using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebNopApp.DependencyManagement;
using WebNopApp.Extensions;
using WebNopApp.Framework.Infrastructure.Extensions;

namespace WebNopApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            WebHostEnvironment = webHostEnvironment;
        }

        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment WebHostEnvironment;
        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

           
            services.ConfigureApplicationServices(Configuration, WebHostEnvironment);

            //EngineContext.Current.Resolve<IDataProvider>().InitializeDatabase();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            // ֱ����Autofacע���Զ���� 
            builder.RegisterModule(new AutofacModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //���Autofac
            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            //��̬�ļ�
            app.UseStaticFiles();

            //·��
            app.UseRouting();

            //��֤
            app.UseAuthentication();

            //��Ȩ
            app.UseAuthorization();

            //ע��·�ɵ�ַ
            app.RegisterRoutes();
        }
    }
}
