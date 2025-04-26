using Application.Services.AuthService;
using Application.Services.BankTransactionService;
using Application.Services.ExpenseCategoryService;
using Application.Services.ExpenseRequetService;
using Application.Services.PaymentMethodService;
using Application.Services.RoleService;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(config => {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
              
                config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IBankTransactionService, BankTransactionManager>();
            services.AddScoped<IExpenseCategoryService, ExpenseCategoryManager>();
            services.AddScoped<IExpenseRequestService, ExpenseRequestManager>();
            services.AddScoped<IPaymentMethodService, PaymentMethodManager>();
            services.AddScoped<IRoleService, RoleManager>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
