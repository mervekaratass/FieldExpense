using Application.Repositories;
using Application.Services.ExpenseCategoryService;
using Application.Services.PaymentMethodService;
using Application.Services.UserService;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using MediatR;

namespace Application.Features.ExpenseRequests.Commands.Update
{
    public class UpdateExpenseRequestCommand : IRequest<UpdateExpenseRequestResponse>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ExpenseCategoryId { get; set; }
        public int PaymentMethodId { get; set; }
        public decimal Amount { get; set; }
        public string Location { get; set; }
        public string? DocumentPath { get; set; }
        public string? Description { get; set; }


        public class UpdateExpenseRequestCommandHandler : IRequestHandler<UpdateExpenseRequestCommand, UpdateExpenseRequestResponse>
        {
            private readonly IExpenseRequestRepository _expenseRequestRepository;
            private readonly IUserService _userService;
            private readonly IExpenseCategoryService _expenseCategoryService;
            private readonly IPaymentMethodService _paymentMethodService;
            private readonly IMapper _mapper;

            public UpdateExpenseRequestCommandHandler(
                IExpenseRequestRepository expenseRequestRepository,
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

            public async Task<UpdateExpenseRequestResponse> Handle(UpdateExpenseRequestCommand request, CancellationToken cancellationToken)
            {
                ExpenseRequest? expenseRequest = await _expenseRequestRepository.GetAsync(er => er.Id == request.Id);
                if (expenseRequest == null)
                    throw new BusinessException("Güncellenmek istenen masraf bulunamadı.");

                var user = await _userService.GetByIdAsync(request.UserId);
                var category = await _expenseCategoryService.GetByIdAsync(request.ExpenseCategoryId);
                var paymentMethod = await _paymentMethodService.GetByIdAsync(request.PaymentMethodId);

                // Mapping
                _mapper.Map(request, expenseRequest);

                await _expenseRequestRepository.UpdateAsync(expenseRequest);

                UpdateExpenseRequestResponse response = _mapper.Map<UpdateExpenseRequestResponse>(expenseRequest);
                response.UserName = user.FirstName + " " + user.LastName;
                response.ExpenseCategoryName = category.Name;
                response.PaymentMethodName = paymentMethod.Name;

                return response;
            }
        }
    }
}
