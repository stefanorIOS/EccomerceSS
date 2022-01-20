using AutoMapper;
using EccomerceSS.Context;
using EccomerceSS.MappingProfile;
using EccomerceSS.Repositories;
using EccomerceSS.Services.ServiceBase;
using EccomerceSS.Utilities.EmailSender;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace EccomerceSS
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfileSS());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json",true,true).AddJsonFile("data.json", true, true);
            var Configuration = configurationBuilder.Build();
            services.AddSingleton<IConfiguration>(Configuration);

            services.AddControllersWithViews();
            services.AddMvc(e =>
            {
                e.EnableEndpointRouting = false;
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                e.Filters.Add(new AuthorizeFilter(policy));



            });

            services.AddTransient(typeof(IRepositoryBase<>),typeof(RepositoryBase<>));
            services.AddTransient(typeof(IServiceBase<>), typeof(ServiceBase<>));
            
            services.AddTransient<INavegationBarRepository,NavegationBarRepository>();
            services.AddTransient<IIndexProductsRepository,IndexProductsRepository>();

            services.AddTransient<IEmailSender, EmailSender>();
            services.AddDbContext<EcommerceContext>(options=>
            {
                options.UseSqlServer(_config.GetConnectionString("EcommerceSS"));
            }
            );
            services.AddAuthorization();
            services.AddIdentity<IdentityUser, IdentityRole>(e =>
             {
                 e.Password.RequiredLength = 1;
                 e.Password.RequiredUniqueChars = 0;
                 e.Password.RequireLowercase = false;
                 e.Password.RequireUppercase = false;
                 e.Password.RequireNonAlphanumeric = false;
                 e.SignIn.RequireConfirmedEmail = true;
             }).AddEntityFrameworkStores<EcommerceContext>().AddDefaultTokenProviders();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env )
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<EcommerceContext>();
                context.Database.Migrate();
                DbInitializer.Initialize(context);
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }
            app.UseStaticFiles();
            app.UseSerilogRequestLogging();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
