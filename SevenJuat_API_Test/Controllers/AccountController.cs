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
    public class AccountController : ControllerBase
    {
        private IAccountData _accountData;

        public AccountController(IAccountData accountData)
        {
            _accountData = accountData;
        }

        [HttpGet]
        [Route("api/[controller]/list")]
        public IActionResult GetAccounts()
        {
            return Ok(_accountData.ListAccounts());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetAccount(Guid id)
        {
            var data = _accountData.GetAccount(id);

            if (data != null)
                return Ok(data);

            return NotFound($"Account No: {id} does not exist.");
        }

        [HttpPost]
        [Route("api/[controller]/create/{accountName}")]
        public IActionResult CreateAccount(string accountName)
        {
            var account = _accountData.CreateAccount(accountName);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + account.AccountId, account);
        }

        [HttpDelete]
        [Route("api/[controller]/delete/{id}")]
        public IActionResult DeleteAccount(Guid id)
        {
            var data = _accountData.GetAccount(id);

            if (data != null)
            {
                _accountData.DeleteAccount(id);
                return Ok();
            }

            return NotFound($"Account No: {id} does not exist.");
        }

        [HttpPatch]
        [Route("api/[controller]/update/{id}/{name}")]
        public IActionResult UpdateAccount(Guid id, string name)
        {
            var existingAccount = _accountData.GetAccount(id);

            if (existingAccount != null)
            {
                _accountData.UpdateAccount(id, name);
                return Ok($"Account No: {id} Name was updated to {name}");
            }

            return NotFound($"Account No: {id} does not exist.");
        }

    }
}
