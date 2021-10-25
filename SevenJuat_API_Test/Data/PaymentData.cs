using Microsoft.EntityFrameworkCore;
using SevenJuat_API_Test.Interfaces;
using SevenJuat_API_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SevenJuat_API_Test.Data
{
    public class PaymentData : IPaymentData
    {
        private SevenContext _dbContext;

        public PaymentData(SevenContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Payment CreatePayment(Guid accountId, decimal amount, string remarks)
        {
            var payment = new Payment();
            payment.PaymentId = Guid.NewGuid();
            payment.AccountId = accountId;
            payment.Status = "Pending"; //default
            payment.Amount = amount;
            payment.Reason = $"Payment for/by {remarks}";

            _dbContext.Payments.Add(payment);
            _dbContext.SaveChanges();
            return payment;
        }

        public bool DeletePayment(Guid id)
        {
            var dataToDelete = _dbContext.Payments.Find(id);
            _dbContext.Payments.Remove(dataToDelete);
            return true;
        }

        public Payment GetPayment(Guid id)
        {
            return _dbContext.Payments.Find(id);
        }

        public List<Payment> GetPaymentByAccount(Guid accountId)
        {
            return _dbContext.Payments
                .Where(x => x.AccountId == accountId)
                .OrderByDescending(x => x.Date)
                .ToList();
        }

        public List<Payment> ListPayments()
        {
            return _dbContext.Payments
                .OrderByDescending(x => x.Date)
                .ToList();
        }

        public Payment UpdatePayment(Guid id)
        {
            var existingData = GetPayment(id);
            existingData.Status = "Paid";
            _dbContext.Payments.Update(existingData);
            _dbContext.SaveChanges();
            return existingData;
        }

       
    }
}
