using CancunHotel.Application.Interfaces;
using CancunHotel.Application.Services;
using CancunHotel.Data.Repository;
using CancunHotel.Domain.Interfaces.Business;
using CancunHotel.Domain.Interfaces.Repositories;
using CancunHotel.Domain.Interfaces.Validations;
using CancunHotel.Domain.Management;
using CancunHotel.Domain.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CancunHotel.CrossCutting.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IBookingRepository, BookingRepository>();

            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IBookingService, BookingService>();

            services.AddScoped<IValidateRoom, ValidateRoom>();
            services.AddScoped<IValidateCustomer, ValidateCustomer>();
            services.AddScoped<IValidateBooking, ValidateBooking>();

            services.AddScoped<IManagementToken, ManagementToken>();

        }


    }
}
