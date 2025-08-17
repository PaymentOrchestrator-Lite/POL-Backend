using Api.Src.Flows.iPaymentFlow;

namespace Api.Src.Infrastructure.Sqlite.Models
{
    public enum ePaymentModelStatus
    {
        Pending,
        Confirmed
    }

    public class PaymentModel : iBaseModal
    {
        // TODO: index 
        public string CustomerId { get; set; }
        public decimal Amount { get; set; }
        public ePaymentModelStatus Status { get; set; }
 
    }
}