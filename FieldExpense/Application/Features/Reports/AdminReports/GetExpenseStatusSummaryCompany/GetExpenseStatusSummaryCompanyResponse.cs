using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Reports.AdminReports.GetExpenseStatusSummaryCompany
{
    public class GetExpenseStatusSummaryCompanyResponse
    {
        public string Period { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }

    }


}
