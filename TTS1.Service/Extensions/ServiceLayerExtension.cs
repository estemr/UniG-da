using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Reflection;
using TTS.Service.FluentValidations;
using TTS.Service.Helpers.Images;
using TTS.Service.Services.Abstractions;
using TTS.Service.Services.Concretes;

namespace TTS.Service.Extensions
{
    public static class DataLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddScoped<IFieldService, FieldService>();
            services.AddScoped<ISensorService, SensorService>();
            services.AddScoped<IImageHelper, ImageHelper>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISensorDataService, SensorDataService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<ITransportService, TransportService>();
            services.AddScoped<IFacilityService, FacilityService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPackageService, PackageService>();
            services.AddScoped<IStageService, StageService>();
            services.AddScoped<ICommentService, CommentService>();


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAutoMapper(assembly);

            services.AddControllersWithViews().AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssemblyContaining<SensorValidator>();
                opt.DisableDataAnnotationsValidation = true;
                opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
            });

           

            return services;
        }
    }
}
