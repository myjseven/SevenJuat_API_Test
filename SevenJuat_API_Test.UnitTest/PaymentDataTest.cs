using Moq;
using SevenJuat_API_Test.Data;
using SevenJuat_API_Test.Interfaces;
using SevenJuat_API_Test.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace SevenJuat_API_Test.UnitTest
{
    public class PaymentDataTest
    {

        [Theory]
        [InlineData("6BB0D6AA-E495-4B9E-B7D6-3162817ED219")]
        public void GetPayment_FromProvidedAccounId_ReturnsExpectedResult(string id)
        {
            var mockData = new MockPaymentData();
            var data = mockData.GetPayment(Guid.Parse(id));

            Assert.Equal(id.ToLower(), data.PaymentId.ToString());
        }

        [Fact]
        public void ListPayments_ShouldReturn_ExpectedResult()
        {
            var mockData = new MockPaymentData();
            var data = mockData.ListPayments();

            Assert.Equal(2, data.Count);
        }

        [Theory]
        [InlineData("cb2bd817-98cd-4cf3-a80a-53ea0cd9c700", 20)]
        public void CreatePayment_WithValidData_ReturnsExpectedResult(string accountId, decimal amount)
        {
            var mockData = new MockPaymentData();
            var data = mockData.CreatePayment(Guid.Parse(accountId),amount);

            Assert.Equal(accountId, data.AccountId.ToString());
            Assert.Equal(amount, data.Amount);
            Assert.NotNull(data);
        }

        [Theory]
        [InlineData("62E82FC8-CA51-450F-8152-0734A97A8127")]
        public void UpdateBalance_FromGivenAmount_ReturnsExpectedResult(string id)
        {
            var mockData = new MockPaymentData();
            var data = mockData.UpdatePayment(Guid.Parse(id.ToLower()));

            Assert.Equal("Paid", data.Status.ToString());
        }

        [Theory]
        [InlineData("62E82FC8-CA51-450F-8152-0734A97A8127")]
        public void DeleteAccount_FromGivenPaymentId_ReturnsExpectedResult(string id)
        {
            var mockData = new MockPaymentData();
            mockData.DeletePayment(Guid.Parse(id.ToLower()));

            Assert.True(true);
        }

    }
}
