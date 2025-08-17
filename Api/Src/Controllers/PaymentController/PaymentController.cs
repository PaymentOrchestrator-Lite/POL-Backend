using Api.Src.Flows.iPaymentFlow;
using Api.Src.Flows.PaymentFlow;
using Microsoft.AspNetCore.Mvc;

namespace Api.Src.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class PaymentController : ControllerBase
{
    private readonly PaymentFlow paymentFlow;
    public PaymentController(PaymentFlow paymentFlow)
    {
        this.paymentFlow = paymentFlow;
    }

    [HttpGet]
    public async Task<IActionResult> getPaymentTable()
    {
        return Ok(await this.paymentFlow.GetPaymentTable());
    }

    [HttpPost]
    public async Task<IActionResult> addNewPendingPayment([FromBody] iAddNewPendingPaymentRequest args)
    {
        return Ok(await this.paymentFlow.AddNewPendingPayment(args));
    }

    [HttpPost]
    public async Task<IActionResult> MarkPaymentAsPaid([FromBody] iMarkPaymentAsPaidRequest args)
    {
        return Ok(await this.paymentFlow.MarkPaymentAsPaid(args));
    }
}