using Application.Features.ExpenseRequests.Commands.Common.Create;
using Application.Repositories;
using Application.Services.ExpenseCategoryService;
using Application.Services.PaymentMethodService;
using Application.Services.UserService;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;


namespace Application.Features.ExpenseRequests.Commands.Employee.CreateForSelf
{
    public class CreateMyExpenseRequestCommand : IRequest<CreateExpenseRequestResponse>, ISecuredRequest
    {
        public int ExpenseCategoryId { get; set; }
        public int PaymentMethodId { get; set; }
        public decimal Amount { get; set; }
        public string Location { get; set; }
        public string? DocumentPath { get; set; }
        public string? Description { get; set; }
        public string[] RequiredRoles => ["Personel"];
        public class CreateMyExpenseRequestCommandHandler : IRequestHandler<CreateMyExpenseRequestCommand, CreateExpenseRequestResponse>
        {
            private readonly IExpenseRequestRepository _expenseRequestRepository;
            private readonly IUserService _userService;
            private readonly IExpenseCategoryService _expenseCategoryService;
            private readonly IPaymentMethodService _paymentMethodService;
            private readonly IMapper _mapper;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public CreateMyExpenseRequestCommandHandler(IExpenseRequestRepository expenseRequestRepository,
                IUserService userService, IExpenseCategoryService expenseCategoryService,
                IPaymentMethodService paymentMethodService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
            {
                _expenseRequestRepository = expenseRequestRepository;
                _userService = userService;
                _expenseCategoryService = expenseCategoryService;
                _paymentMethodService = paymentMethodService;
                _mapper = mapper;
                _httpContextAccessor = httpContextAccessor;
            }

            public async Task<CreateExpenseRequestResponse> Handle(CreateMyExpenseRequestCommand request, CancellationToken cancellationToken)
            {
                int userId = int.Parse(_httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value!);

                Domain.Entities.User? user = await _userService.GetByIdAsync(userId);
                ExpenseCategory? expenseCategory = await _expenseCategoryService.GetByIdAsync(request.ExpenseCategoryId);
                PaymentMethod? paymentMethod = await _paymentMethodService.GetByIdAsync(request.PaymentMethodId);

                ExpenseRequest expenseRequest = _mapper.Map<ExpenseRequest>(request);
                expenseRequest.UserId = userId;
                expenseRequest.Status = ExpenseStatus.Bekliyor;
                expenseRequest.IsPaid = false;


                await _expenseRequestRepository.AddAsync(expenseRequest);

                var response = _mapper.Map<CreateExpenseRequestResponse>(expenseRequest);
                response.UserName = user.FirstName + " " + user.LastName;

                return response;
            }
        }
    }

}
