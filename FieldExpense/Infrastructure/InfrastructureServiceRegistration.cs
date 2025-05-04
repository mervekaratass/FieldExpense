using Application.Services.PaymentGatewayService;
using Application.Services.ReportService;
using Infrastructure.Contexts;
using Infrastructure.Services.PaymentGateway;
using Infrastructure.Services.Report;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure
{

    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<DapperContext>();
            services.AddScoped<IReportService, ReportManager>();
            services.AddScoped<IPaymentGatewayService,PaymentGatewayManager>();
            return services;
        }
    }
}
