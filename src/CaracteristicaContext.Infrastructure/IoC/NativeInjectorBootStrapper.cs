using CaracteristicaContext.Domain.AggregatesModel.CaracteristicaAggregate;
using CaracteristicaContext.Domain.AggregatesModel.CaracteristicaAggregate.Commands;
using CaracteristicaContext.Infrastructure.Repository;
using Core.Domain.Notification;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CaracteristicaContext.Infrastructure.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddMediatR();
            services.AddScoped<ICaracteristicaRepository, CaracteristicaRepository>();
            services.AddScoped<IRequestHandler<IncluirCaracteristicaCommand>, CaracteristicaHandle>();

            services.AddScoped<INotificationHandler<NotificationDomain>, NotificationHandle>();
        }
    }
}
