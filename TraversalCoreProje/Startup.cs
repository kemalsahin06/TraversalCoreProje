using BusinessLayer.Container;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using TraversalCoreProje.Cors.Handlers.DestinationHandlers;
using TraversalCoreProje.Models;

namespace TraversalCoreProje
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

			services.AddScoped<GetAllDestinationQueryHandler>(); // bu i�lemide startap taraf�nda yapmmam�z laz�m CQRS ���C
			services.AddScoped<GetDestinationByIDQueryHandler>(); // bu i�lemide startap taraf�nda yapmmam�z laz�m CQRS ���C
			services.AddScoped<CreateDestinationCommandHandler>(); // bu i�lemide startap taraf�nda yapmmam�z laz�m CQRS ���C
			services.AddScoped<RemoveDestinationCommentHandle>(); // bu i�lemide startap taraf�nda yapmmam�z laz�m CQRS ���C
			services.AddScoped<UpdateDestinationCommentHandle>(); // bu i�lemide startap taraf�nda yapmmam�z laz�m CQRS ���C


			services.AddMediatR(typeof(Startup)); // bu �ekilde l�sa bir sekilde tek seferde yapabiliyoruz yada usteki gibi teker teker yazacag�z



			services.AddLogging(x =>
			{

				x.ClearProviders();
				x.SetMinimumLevel(LogLevel.Debug);
				x.AddDebug();
			});




			/// burda sisteme outhorize i�lemi  ger�ekle�tiriliyo
			services.AddDbContext<Context>();
			services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidation>().AddEntityFrameworkStores<Context>();



			services.AddHttpClient();


			// bu sin�f� businis layer katman�nda tan�mlad�m
			services.ContainerDependencies();  //BasicBlockKind yam-nint nas�l kullanm�s�m falan diye


			services.AddAutoMapper(typeof(Startup)); // bunu da ben ekledim bu map lemek i�ir

			services.AddTransient<IValidator<AnnouncementAddDTOs>, AnnouncementValidator>(); // bunlar� dto s i�in dahil ediyorum
																							 // bunlar� dto s i�in dahil ediyorum

			services.CustomerValidator();

			services.AddControllersWithViews().AddFluentValidation(); // bunu da usteki ile birlikte ekledim


            services.AddControllersWithViews();
            services.AddMvc(config =>
			{
				var policy = new AuthorizationPolicyBuilder()
				.RequireAuthenticatedUser()
				.Build();
				config.Filters.Add(new AuthorizeFilter(policy));
			}
			);


			services.AddLocalization(opt =>
			{

				opt.ResourcesPath = "Resources";
			}
			);




			services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization(); // burda dil destegini ekledim

			/// burda biiti

			services.ConfigureApplicationCookie(options =>  // oatanti olmadan giri� yapm�ssa buraya yonlendir demek

			{
				options.LogoutPath = "/Login/SingIn/";
			});
			
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
		{

			var path = Directory.GetCurrentDirectory();
			loggerFactory.AddFile($"{path}\\Logs\\Log1.txt");

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

			app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "? code={0}"); // bu tan�ms�z bir sayfaya gidecegi zaman

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseAuthentication(); // bunu da biraya yaz�yoruz yanl�z bunlar�n s�ras� �nemli
			app.UseRouting();

			app.UseAuthorization();



			var suppertesCulteres = new[] { "en", "fr", "es", "gr", "tr","de"};
			var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(suppertesCulteres[4]).AddSupportedCultures(suppertesCulteres).AddSupportedUICultures(suppertesCulteres);
			
			app.UseRequestLocalization(localizationOptions);
			// yukar�dada dil destegini ile yapt�m




			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});


			// bunu areas kulland�g�m i�in burda tan�mlad�m fonksiyon kendi verdi yani
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
