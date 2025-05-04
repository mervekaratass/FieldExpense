using Application.Services.BankTransactionService;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.PaymentGatewayService
{
    public interface IPaymentGatewayService
    {
        //ödeme simülasyonu
        Task<BankTransaction> CreateTransactionAsync(CreateBankTransactionModel model);
    }
}
