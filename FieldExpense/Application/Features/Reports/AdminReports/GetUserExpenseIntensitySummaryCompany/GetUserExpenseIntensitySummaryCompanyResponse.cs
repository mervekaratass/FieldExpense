using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Reports.AdminReports.GetUserExpenseIntensitySummaryCompany
{
    public class GetUserExpenseIntensitySummaryCompanyResponse
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Period { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }


    }

}
