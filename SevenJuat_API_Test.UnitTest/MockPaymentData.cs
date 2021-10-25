using SevenJuat_API_Test.Interfaces;
using SevenJuat_API_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenJuat_API_Test.UnitTest
{
    public class MockPaymentData : IPaymentData
    {
        public List<Payment> paymentList = new List<Payment>()
        {
            new Payment()
            {
                PaymentId = new Guid("62E82FC8-CA51-450F-8152-0734A97A8127"),
                AccountId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                Date = DateTime.Now,
                Amount = 10,
                Status = "Pending",
                Reason = "Test"
            },
            new Payment()
            {
                PaymentId = new Guid("6BB0D6AA-E495-4B9E-B7D6-3162817ED219"),
                AccountId = new Guid("cb2bd817-98cd-4cf3-a80a-53ea0cd9c700"),
                Date = DateTime.Now,
                Amount = 50,
                Status = "Paid",
                Reason = "Test"
            }
        };

        public Payment CreatePayment(Guid accountId, decimal amount, string remarks = null)
        {
            var payment = new Payment();
            payment.PaymentId = Guid.NewGuid();
            payment.AccountId = accountId;
            payment.Status = "Pending"; 
            payment.Amount = amount;
            payment.Reason = $"Payment for/by {remarks}";

            return payment;
        }

        public bool DeletePayment(Guid id)
        {
            var dataToDelete = paymentList.Single(x => x.PaymentId.Equals(id));
            paymentList.Remove(dataToDelete);
            return true;
        }

        public Payment GetPayment(Guid id)
        {
            return paymentList.Single(x => x.PaymentId.Equals(id));
        }

        public List<Payment> GetPaymentByAccount(Guid accountId)
        {
            return paymentList
               .Where(x => x.AccountId == accountId)
               .OrderByDescending(x => x.Date)
               .ToList();
        }

        public List<Payment> ListPayments()
        {
            return paymentList;
        }

        public Payment UpdatePayment(Guid paymentId)
        {
            var existingData = GetPayment(paymentId);
            existingData.Status = "Paid";
            return existingData;
        }
    }
}
