using BusinessLayer.Abstract;
using BusinessLayer.Abstract.UOFAbstract;
using BusinessLayer.Concrete;
using BusinessLayer.Concrete.UOWConcrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UintOfWork;
using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;
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
        public static void ContainerDependencies(this IServiceCollection services)
        {
            //services.AddControllersWithViews();
            services.AddScoped<ICommentService, CommentManager>();//belirtilen işlemlerde  uzun şekilde tanımlamaktansa buraya tanımlayıp geri kalanında az ve temiz kod yazıldı
            services.AddScoped<ICommentDal, EfCommentDal>();

            services.AddScoped<IDestinationsService, DestinationManager>();
            services.AddScoped<IDestinationDal, EfDestinationsDal>();

            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserDal>();

            services.AddScoped<IReservationService, ReservationManager>();
            services.AddScoped<IReservationDal, EfReservationDal>();

            services.AddScoped<IGuideService, GuideManager>();
            services.AddScoped<IGuideDal, EfGuideDal>();

            services.AddScoped<IExcelService, ExcelManager>();
            services.AddScoped<IPdfService, PdfManager>();

            services.AddScoped<IContactUsService, ContactUsManager>();
            services.AddScoped<IContactUsDal, EfContactUsDal>();

            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();

            services.AddScoped<IAccountService, AccountManager>();
            services.AddScoped<IAccountDal, EfAccountDal>();

            services.AddScoped<IUOWDal, UOWDal>();

        }
        public static void CustomerValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AnnouncementAddDTO>, AnnouncementValidator>(); // dto validasyonları busisnesslayer çalıştırmak için
        }
    }
}
