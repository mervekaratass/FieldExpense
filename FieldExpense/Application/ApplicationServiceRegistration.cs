using Application.Services.AuthService;
using Application.Services.BankTransactionService;
using Application.Services.ExpenseCategoryService;
using Application.Services.ExpenseRequetService;
using Application.Services.PaymentMethodService;
using Application.Services.RoleService;
using Microsoft.Extensions.DependencyInjection;


namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
         
            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IBankTransactionService, BankTransactionManager>();
            services.AddScoped<IExpenseCategoryService, ExpenseCategoryManager>();
            services.AddScoped<IExpenseRequestService, ExpenseRequestManager>();
            services.AddScoped<IPaymentMethodService, PaymentMethodManager>();
            services.AddScoped<IRoleService, RoleManager>();
         
            return services;
        }
    }
}
