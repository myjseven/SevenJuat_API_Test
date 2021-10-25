using SevenJuat_API_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SevenJuat_API_Test.Interfaces
{
    public interface IAccountData
    {
        List<Account> ListAccounts();
        Account GetAccount(Guid id);
        Account CreateAccount(string accountName);
        bool DeleteAccount(Guid id);
        Account UpdateAccount(Guid id, string name);
        Account UpdateBalance(Guid id, decimal amount);


    }
}
