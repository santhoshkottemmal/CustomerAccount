using CustomerAccount.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace CustomerAccount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        public static RetailBankingContext db = new RetailBankingContext();


        [HttpPost]
        //[Route("CreateCustomerAccount")]
        public async Task<ActionResult> CreateCustomerAccount(int CustomerId)
        {
            if (ModelState.IsValid)
            {
                var customerAccount = new Models.CustomerAccount();

                customerAccount.CustomerId = CustomerId;
                customerAccount.AccountType = "Savings Account";
                customerAccount.CreatedDate = DateTime.Now;
                customerAccount.Narration = "New Account";
                Random r = new Random();
                customerAccount.ChequeNo = r.Next();
                customerAccount.ValueDate = DateTime.Now;
                customerAccount.Withdrawal = 0;
                customerAccount.Deposit = 0;
                customerAccount.ClosingBalance = 0;

                db.Add(customerAccount);

                await db.SaveChangesAsync();
                return Ok();
            }
            else { return BadRequest(); }

        }

        
        [HttpGet]
        [Route("{CustomerId}")]
        public async Task<ActionResult> getCustomerAccounts(int CustomerId)
        {
            var C = await db.CustomerAccounts.FindAsync(CustomerId);

            if (C != null) { return Ok(C); }
            else { return NotFound(); }

        }

        [HttpGet]
        [Route("{AccountId}/{from_date}/{to_date}")]
        public async Task<ActionResult> getAccountStatement(int AccountId, DateTime from_date,DateTime to_date )
        {
            var C = db.CustomerAccounts.Where(i => i.CreatedDate>= from_date & i.CreatedDate >= to_date);

            if (C != null) { return Ok(C); }
            else { return NotFound(); }

        }

        [HttpPut]
        [Route("deposit/{AccountId}/{amount}")]
        public async Task<ActionResult> deposit(int AccountId, int amount)
        {
           var cus =db.CustomerAccounts.Where(i => i.AccountId == AccountId).FirstOrDefault();
            cus.Deposit = cus.Deposit+ amount;
            db.Update(cus);
            await db.SaveChangesAsync();
            return Ok(cus);
        }

        [HttpPut]
        [Route("withdraw/{Accountid}/{amountToWithdraw}")]
        public async Task<ActionResult> withdraw(int Accountid, int amountToWithdraw)
        {
            var cus = db.CustomerAccounts.Where(i => i.AccountId == Accountid).FirstOrDefault();
            cus.Deposit = cus.Deposit - amountToWithdraw;
            db.Update(cus);
            await db.SaveChangesAsync();
            return Ok(cus);
        }
    }
}
