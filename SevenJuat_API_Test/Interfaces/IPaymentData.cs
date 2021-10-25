using SevenJuat_API_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SevenJuat_API_Test.Interfaces
{
    public interface IPaymentData
    {
        List<Payment> ListPayments();
        Payment GetPayment(Guid id);
        List<Payment> GetPaymentByAccount(Guid accountId);
        Payment CreatePayment(Guid accountId, decimal amount, string remarks = null);
        bool DeletePayment(Guid id);
        Payment UpdatePayment(Guid id);
    }
}
