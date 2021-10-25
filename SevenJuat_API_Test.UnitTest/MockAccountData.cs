using SevenJuat_API_Test.Interfaces;
using SevenJuat_API_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenJuat_API_Test.UnitTest
{
    public class MockAccountData : IAccountData
    {
        public List<Account> accountList = new List<Account>()
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


        public Account CreateAccount(string accountName)
        {
            var account = new Account();
            account.AccountId = Guid.NewGuid();
            account.AccountName = accountName;
            account.Balance = 100; // default

            return account;
        }

        public bool DeleteAccount(Guid id)
        {
            var dataToDelete = accountList.Single(x => x.AccountId.Equals(id));
            accountList.Remove(dataToDelete);
            return true;
        }

        public Account GetAccount(Guid id)
        {
            return accountList.Single(x => x.AccountId.Equals(id));
        }

        public List<Account> ListAccounts()
        {
            return accountList;
        }

        public Account UpdateAccount(Guid id, string name)
        {
            var existingData = GetAccount(id);
            existingData.AccountName = name;
            return existingData;
        }

        public Account UpdateBalance(Guid id, decimal amount)
        {
            var existingData = GetAccount(id);
            existingData.Balance = existingData.Balance + amount;
            return existingData;
        }
    }
}
