

namespace Application.Features.Reports.GetTotalPaymentSummaryCompany
{
    public class GetTotalPaymentSummaryCompanyResponse
    {
        public string Period { get; set; } = string.Empty; // Gün / Hafta / Ay bilgisi
        public decimal TotalAmount { get; set; }
    }
}
