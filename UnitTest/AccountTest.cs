using SevenJuat_API_Test.Interfaces;
using SevenJuat_API_Test.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTest
{
    public class AccountTest
    {
        public List<Account> accounts = new List<Account>()
        {
            new Account()
            {
                AccountId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                AccountName = "First Account",
                Balance = 100
            },
            new Account()
            {
                AccountId = new Guid("cb2bd817-98cd-4cf3-a80a-53ea0cd9c700"),
                AccountName = "Second Account",
                Balance = 100
            }
        };

        private IAccountData _accountData;

        public AccountTest(IAccountData accountData)
        {
            _accountData = accountData;
        }

        [Fact]
        public void ListAccount_ShouldReturn_ExistingAccounts()
        {
            var result = _accountData.GetAccount(Guid.Parse("cb2bd817-98cd-4cf3-a80a-53ea0cd9c700"));
            Assert.Equal("Second Account", result.AccountName);
        }
    }
}
