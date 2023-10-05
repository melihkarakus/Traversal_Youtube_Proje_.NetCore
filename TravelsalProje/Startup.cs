using BusinessLayer.Container;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using TravelsalProje.CQRS.Commands.DestinationCommands;
using TravelsalProje.CQRS.Handlers.DestinationHandler;
using TravelsalProje.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc.Razor;

namespace TravelsalProje
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
            services.AddScoped<GetAllDestinationQueryHandler>();//bunu buraya CQRS içinde tanýmladýðýmýz handler yazýyoruz
            services.AddScoped<GetDestinationByIDQueryHandler>();                                                                                                                                                                // son eklenen yukarýdaki .AddErrorDescriber<CustomIdentityValidatior>().AddEntityFrameworkStores<Context>(); bu kodlar bizim parolada kurallarý çýkarmasý için yazýlan kodlamadýr.
            services.AddScoped<CreateDestinationCommandHandler>();
            services.AddScoped<RemoveDestinationCommandHandler>();
            services.AddScoped<UpdateDestinationCommandHandler>();

            services.AddMediatR(typeof(Startup));

            services.AddLogging(x =>
            {
                x.ClearProviders();
                x.SetMinimumLevel(LogLevel.Debug);
                x.AddDebug();
            });


            services.AddDbContext<Context>(); //Ýdentity context eklemek için kullanýlýr
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidatior>().AddEntityFrameworkStores<Context>(); //Ýdentity içindeki sýnýflarý çaðýrmak için kullanýlýr 

            services.AddHttpClient(); 

            services.ContainerDependencies();
            // burada yukarýda tanýmlamadýðýmýz iþlemler için bir güvenlik uyarýsý gibi tanýmlanabilir. Tanýmlanmalý 
            services.AddAutoMapper(typeof(Startup)); //dto eklenmesi için


            services.AddControllersWithViews().AddFluentValidation();

            services.CustomerValidator();//extetions tanýmlanan customervalidator buraya çaðýrdýk

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddLocalization(opt =>
            {
                opt.ResourcesPath = "Resources";
            });

            services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();


            services.ConfigureApplicationCookie(option =>
            {
                option.LoginPath = "/Login/SignIn";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env , ILoggerFactory loggerFactory)
        {
            var path = Directory.GetCurrentDirectory();//path oluþturmaya yarayan kod
            loggerFactory.AddFile($"{path}\\Logs\\Log1.txt");//loglama yani bir kullanýcýnýn ne veri giriþini yaptýðýný tutabiliriz

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404","?code={0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication(); //Kullanýcý giriþ yapmazsa belirli sayfalara eriþemesin diye konulan method
            app.UseRouting();

            app.UseAuthorization();
            var supportedCultures = new[] { "en", "fr", "es", "gr", "tr", "de" };
            var localizationOption = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[4])
                .AddSupportedCultures(supportedCultures).AddSupportedUICultures(supportedCultures);
            app.UseRequestLocalization(localizationOption);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
