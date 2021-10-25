using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SevenJuat_API_Test.Interfaces;
using SevenJuat_API_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SevenJuat_API_Test.Controllers
{
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private IPaymentData _paymentData;
        private IAccountData _accountData;

        public PaymentController(IPaymentData paymentData, IAccountData accountData)
        {
            _paymentData = paymentData;
            _accountData = accountData;
        }

        [HttpGet]
        [Route("api/[controller]/list")]
        public IActionResult GetPayments()
        {
            return Ok(_paymentData.ListPayments());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetPayment(Guid id)
        {
            var data = _paymentData.GetPayment(id);

            if (data != null)
                return Ok(data);

            return NotFound($"Payment No: {id} does not exist.");
        }

        [HttpGet]
        [Route("api/[controller]/account/{accoundId}")]
        public IActionResult GetPaymentsByAccount(Guid accoundId)
        {
            var data = _paymentData.GetPaymentByAccount(accoundId);

            if (data != null)
                return Ok(data);

            return NotFound($"Accound No: {accoundId} does not exist.");
        }

        [HttpPost]
        [Route("api/[controller]/pay/{sourceAccount}/{payToAccount}/{amount}")]
        public IActionResult CreatePayment(Guid sourceAccount, Guid payToAccount, decimal amount)
        {
            var sourceAccountData = _accountData.GetAccount(sourceAccount);
            var payToAccountData = _accountData.GetAccount(sourceAccount);

            if (sourceAccountData != null && payToAccountData != null)
            {
                var pay = _paymentData.CreatePayment(payToAccount, amount, sourceAccountData.AccountName);
                _paymentData.CreatePayment(sourceAccount, amount * -1);
                _accountData.UpdateBalance(sourceAccount, amount * -1);
                _accountData.UpdateBalance(payToAccount, amount);

                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + pay.PaymentId, pay);
            }

            return NotFound($"Account No: {sourceAccount} or {payToAccount} does not exist.");
        }

        [HttpPatch]
        [Route("api/[controller]/accept/{id}")]
        public IActionResult AcceptPayment(Guid id)
        {
            var data = _paymentData.GetPayment(id);

            if (data != null)
            {
                var updated = _paymentData.UpdatePayment(id);
                return Ok(data);
            }

            return NotFound($"Payment No: {id} does not exist.");
        }

    }
}
