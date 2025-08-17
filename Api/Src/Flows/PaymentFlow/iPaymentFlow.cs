using Api.Src.Infrastructure.Sqlite.Models;

namespace Api.Src.Flows.iPaymentFlow
{
    public class iGetPaymentTableResponse
    {
        public String Id { get; set; }
        public String UserFk { get; set; }
        public Decimal Amount { get; set; }
        public ePaymentModelStatus Status { get; set; }


        public iGetPaymentTableResponse() { }
        public iGetPaymentTableResponse(PaymentModel paymentModel)
        {
            this.Id = paymentModel.Id.ToString();
            this.UserFk = paymentModel.CustomerId;
            this.Amount = paymentModel.Amount;
            this.Status = paymentModel.Status;
        }
    }

    public class iAddNewPendingPaymentRequest
    {
        public String UserFk { get; set; }
        public Decimal Amount { get; set; }
    }

    public class iMarkPaymentAsPaidRequest
    {
        public String Id { get; set; }
    }
}
