using Api.Src.Flows.iPaymentFlow;
using Api.Src.Infrastructure.Sqlite.Models;
using Api.Src.Services.PaymentService;
using Api.Src.Util.Di;
using Api.Src.Util.FrontendUtil;


namespace Api.Src.Flows.PaymentFlow
{
    [iBaseServiceAttribute(eServiceScope.Scoped)]
    public class PaymentFlow
    {
        private readonly PaymentService _paymentService;
        public PaymentFlow(PaymentService paymentService)
        {
            this._paymentService = paymentService;
        }

        public async Task<List<iGetPaymentTableResponse>> GetPaymentTable()
        {
            List<PaymentModel> paymentModels = await this._paymentService.GetPaymentTableToListAsync();
            List<iGetPaymentTableResponse> result = new List<iGetPaymentTableResponse>();

            foreach (var paymentModel in paymentModels)
            {
                result.Add(new iGetPaymentTableResponse(paymentModel));
            }
            return result;
        }

        public async Task<object> AddNewPendingPayment(iAddNewPendingPaymentRequest args)
        {
            var paymentModel = new PaymentModel();
            paymentModel.Status = ePaymentModelStatus.Pending;
            paymentModel.CustomerId = args.UserFk;
            paymentModel.Amount = args.Amount;

            await this._paymentService.AddPaymentRecordAsync(paymentModel);
            return FrontendUtil.AlertForm("Added new pending payment.", eAlertForm.Success);
        }

        public async Task<object> MarkPaymentAsPaid(iMarkPaymentAsPaidRequest args)
        {
            // TODO: Cant define it everytime
            Guid guidId = Guid.Parse(args.Id);
            var paymentModel = await this._paymentService.GetPaymentByIdAsync(guidId);

            if (paymentModel == null) {
                return FrontendUtil.AlertForm("Unable to find that payment record. Please try again.", eAlertForm.Failed);
            }
            paymentModel.Status = ePaymentModelStatus.Confirmed;
            await this._paymentService.UpdatePaymentAsync(paymentModel);

            return FrontendUtil.AlertForm("Payment modal succesfully updated.", eAlertForm.Success);
        }
    }
}