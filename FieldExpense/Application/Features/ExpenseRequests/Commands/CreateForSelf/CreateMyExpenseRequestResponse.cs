using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ExpenseRequests.Commands.CreateForSelf
{
        public class CreateMyExpenseRequestResponse
        {

            public int Id { get; set; }
            public int UserId { get; set; }
            public string UserName { get; set; } // yeni eklendi

            public int ExpenseCategoryId { get; set; }
            public string ExpenseCategoryName { get; set; } // yeni eklendi

            public int PaymentMethodId { get; set; }
            public string PaymentMethodName { get; set; } // yeni eklendi

            public decimal Amount { get; set; }
            public string Location { get; set; }
            public string? DocumentPath { get; set; }
            public string? Description { get; set; }
            public string Status { get; set; }
        }
    }


