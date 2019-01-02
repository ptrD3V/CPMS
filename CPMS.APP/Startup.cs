using CPMS.BL.Common.Profile;
using CPMS.BL.Factories;
using CPMS.BL.Services;
using CPMS.DAL.Context;
using CPMS.DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace CPMS.APP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<ManagementSystemContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // register repositories
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IBillingInfoRepository, BillingInfoRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IDeveloperRepository, DeveloperRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ITimeRepository, TimeRepository>();

            // register factories
            services.AddScoped<IAddressFactory, AddressFactory>();
            services.AddScoped<IBillingInfoFactory, BillingInfoFactory>();
            services.AddScoped<ICustomerFactory, CustomerFactory>();

            // register services
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IBillingInfoService, BillingInfoService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IDeveloperService, DeveloperService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<ITimeService, TimeService>();

            var config = new AutoMapper.MapperConfiguration(c =>
            {
                c.AddProfile(new ApplicationProfile());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "CPMS.API", Description = "CPMS Swagger Core API"} );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CPMS Swagger Core API");
            });
        }
    }
}
