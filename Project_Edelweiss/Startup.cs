using System;
using System.Globalization;
using Edelweiss.BLL.Infrastructure;
using Edelweiss.BLL.Interfaces;
using Edelweiss.BLL.Services;
using Edelweiss.DAL.EF;
using Edelweiss.DAL.Entities;
using Edelweiss.DAL.Interfaces;
using Edelweiss.DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Project_Edelweiss.Configuration;
using Project_Edelweiss.Services;

namespace Project_Edelweiss
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AutomapperInit.Initialize();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>(options => {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>();


            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromSeconds(600);
            });

            //services.AddIdentity<User, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IUnitOfWork, EFUnitOfWork>();
            services.AddTransient<IAgentRepository, AgentRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IRepository<SysTransaction>, SysTransactionRepository>();
            services.AddTransient<IRepository<CellPhoneMask>, CellPhoneMaskRepository>();
            services.AddTransient<ICommissionRepository, CommissionRepository>();
            services.AddTransient<ICommissionsDividingRepository, CommissionDividingRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<IRepository<Currency>, CurrencyRepository>();
            services.AddTransient<IRepository<Range>, RangeRepository>();
            services.AddTransient<IRepository<Tariff>, TariffRepository>(); 
            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ISysTransactionRepository, SysTransactionRepository>();
            services.AddTransient<IEmailSender, EmailSender>();
           // services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IAgentService, AgentService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<ICommissionService, CommissionService>();
            services.AddTransient<ICommissionsDividingService, CommissionsDividingService>();
            services.AddTransient<ICurrencyService, CurrencyService>(); 
            services.AddTransient<ISysTransactionService, SysTransactionService>();
            services.AddTransient<ICellPhoneMaskService, CellPhoneMaskService>();
            services.AddTransient<IRangeService, RangeService>();
            services.AddTransient<ITariffService, TariffService>();
            services.AddTransient<FileUploadService>();
            //services.AddDistributedMemoryCache();
            //services.AddSession(options =>
            //{
            //    options.IdleTimeout = TimeSpan.FromSeconds(10);
            //    options.Cookie.HttpOnly = true;
            //});
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddMvc().AddViewLocalization();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //app.UseSession();

            

            app.UseStaticFiles();
            var supportedCultures = new[]
            {
                new CultureInfo("en"),
                new CultureInfo("de"),
                new CultureInfo("ru")
            };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("ru"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            loggerFactory.AddFile("Logs/ClientRequestLog-{Date}.txt", LogLevel.Error);
        }
    }
}
