
using Application.Repositories;
using Application.Services.ExpenseCategoryService;
using Application.Services.PaymentMethodService;
using Application.Services.User;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.ExpenseRequests.Commands.Create
{
    public class CreateExpenseRequestCommand : IRequest<CreateExpenseRequestResponse>,ISecuredRequest
    {
        public int UserId { get; set; }
        public int ExpenseCategoryId { get; set; }
        public int PaymentMethodId { get; set; }
        public decimal Amount { get; set; }
        public string Location { get; set; }
        public string? DocumentPath { get; set; }
        public string? Description { get; set; }
        public string[] RequiredRoles => ["Admin"];
        public class CreateExpenseRequestCommandHandler : IRequestHandler<CreateExpenseRequestCommand, CreateExpenseRequestResponse>
        {
            private readonly IExpenseRequestRepository _expenseRequestRepository;
            private readonly IUserService _userService;
            private readonly IExpenseCategoryService _expenseCategoryService;
            private readonly IPaymentMethodService _paymentMethodService;
            private readonly IMapper _mapper;

            public CreateExpenseRequestCommandHandler(IExpenseRequestRepository expenseRequestRepository, 
                IUserService userService,
                IExpenseCategoryService expenseCategoryService,
                IPaymentMethodService paymentMethodService, 
                IMapper mapper)
            {
                _expenseRequestRepository = expenseRequestRepository;
                _userService = userService;
                _expenseCategoryService = expenseCategoryService;
                _paymentMethodService = paymentMethodService;
                _mapper = mapper;
            }

            public async Task<CreateExpenseRequestResponse> Handle(CreateExpenseRequestCommand request, CancellationToken cancellationToken)
            {
                // User kontrol
                var user = await _userService.GetByIdAsync(request.UserId);
            
                // ExpenseCategory kontrol
                var category = await _expenseCategoryService.GetByIdAsync(request.ExpenseCategoryId);
              

                // PaymentMethod kontrol
                var paymentMethod = await _paymentMethodService.GetByIdAsync(request.PaymentMethodId);
          

                ExpenseRequest expenseRequest = _mapper.Map<ExpenseRequest>(request);
                expenseRequest.Status = ExpenseStatus.Bekliyor; // Yeni eklenen masraflar direkt Pending olacak
                expenseRequest.IsPaid = false; // İlk başta ödeme yapılmadı

                await _expenseRequestRepository.AddAsync(expenseRequest);

                CreateExpenseRequestResponse response = _mapper.Map<CreateExpenseRequestResponse>(expenseRequest);
                response.UserName = user.FirstName + " " + user.LastName;
                response.ExpenseCategoryName = category.Name;
                response.PaymentMethodName = paymentMethod.Name;

                return response;


         
            }
        }
    }
}
