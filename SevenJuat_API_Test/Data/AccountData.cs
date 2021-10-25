using Microsoft.EntityFrameworkCore;
using SevenJuat_API_Test.Interfaces;
using SevenJuat_API_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SevenJuat_API_Test.Data
{
    public class AccountData : IAccountData
    {
        private SevenContext _dbContext;

        public AccountData(SevenContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Account CreateAccount(string accountName)
        {
            var account = new Account();
            account.AccountId = Guid.NewGuid();
            account.AccountName = accountName;
            account.Balance = 100; // default

            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();
            return account;
        }

        public bool DeleteAccount(Guid id)
        {
            var dataToDelete = _dbContext.Accounts.Find(id);
            _dbContext.Accounts.Remove(dataToDelete);
            _dbContext.SaveChanges();
            return true;
        }

        public Account GetAccount(Guid id)
        {
            return _dbContext.Accounts
                    .Include(p => p.Payments
                               .OrderByDescending(x => x.Date)
                         )
                    .FirstOrDefault(x => x.AccountId.Equals(id));
        }

        public List<Account> ListAccounts()
        {
            return _dbContext.Accounts
                .Include(p => p.Payments
                               .OrderByDescending(x => x.Date)
                         )
                .ToList();
        }

        public Account UpdateAccount(Guid id, string name)
        {
            var existingData = GetAccount(id);
            existingData.AccountName = name;
            _dbContext.Accounts.Update(existingData);
            _dbContext.SaveChanges();
            return existingData;
        }

        public Account UpdateBalance(Guid id, decimal amount)
        {
            var existingData = GetAccount(id);
            existingData.Balance = existingData.Balance + amount;
            _dbContext.Accounts.Update(existingData);
            _dbContext.SaveChanges();
            return existingData;
        }
    }
}
