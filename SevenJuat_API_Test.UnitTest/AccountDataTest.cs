using Moq;
using SevenJuat_API_Test.Data;
using SevenJuat_API_Test.Interfaces;
using SevenJuat_API_Test.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace SevenJuat_API_Test.UnitTest
{
    public class AccountDataTest
    {

        [Theory]
        [InlineData("cb2bd817-98cd-4cf3-a80a-53ea0cd9c700")]
        public void GetAccount_FromProvidedAccounId_ReturnsExpectedResult(string id)
        {
            var mockData = new MockAccountData();
            var data = mockData.GetAccount(Guid.Parse(id));

            Assert.Equal("First Account", data.AccountName.ToString());
        }

        [Fact]
        public void ListAccounts_ShouldReturn_ExpectedResult()
        {
            var mockData = new MockAccountData();
            var data = mockData.ListAccounts();

            Assert.Equal(2, data.Count);
        }

        [Theory]
        [InlineData("Test Account")]
        public void CreateAccount_FromGivenAccountName_ReturnsExpectedResult(string name)
        {
            var mockData = new MockAccountData();
            var data = mockData.CreateAccount(name);

            Assert.Equal(name, data.AccountName.ToString());
            Assert.NotNull(data);
        }

        [Theory]
        [InlineData("cb2bd817-98cd-4cf3-a80a-53ea0cd9c700", 30.5)]
        public void UpdateBalance_FromGivenAmount_ReturnsExpectedResult(string id, decimal amount)
        {
            var mockData = new MockAccountData();
            var data = mockData.UpdateBalance(Guid.Parse(id), amount);

            Assert.Equal(100 + amount, data.Balance);
        }

        [Theory]
        [InlineData("cb2bd817-98cd-4cf3-a80a-53ea0cd9c700")]
        public void DeleteAccount_FromGivenAccountId_ReturnsExpectedResult(string id)
        {
            var mockData = new MockAccountData();
            mockData.DeleteAccount(Guid.Parse(id));

            Assert.True(true);
        }

    }
}
