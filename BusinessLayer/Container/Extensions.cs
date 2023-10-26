using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services) // burda mimleme işlemi yaptım
        {
            services.AddScoped<ICommentService, CommentManager>(); // altttakini ve bu satirı generic hale getirmek için yazdım  gidip bakabilirsin
            services.AddScoped<ICommentDal, EfCommentDal>();


            services.AddScoped<IDestinationService, DestinationManager>(); 
            services.AddScoped<IDestinationDal ,EfDestinationDal >();


            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserDal>();

            services.AddScoped<IRezervationServices, RezervationManager>();
            services.AddScoped<IRezervationDal, EfRezervationDal>();

            services.AddScoped<IGuideService, GuideManager>();
            services.AddScoped<IGuideDal, EfGuideDal>();

            services.AddScoped<IContactUsService, ContactUsManager>();
            services.AddScoped<IContactUsDal, EfContactUsDal>();

            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();


            services.AddScoped<IExcelService, ExcelManager>();

            services.AddScoped<IPdfService, PdfManager>();


        }
    }
}
