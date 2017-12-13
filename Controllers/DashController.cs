using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAccount.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankAccount.Controllers
{
    public class DashController : Controller
    {
        private AccountContext _context;
 
        public DashController(AccountContext context)
        {
            _context = context;
        }

        [Route("account/{id}")]
        [HttpGet]
        public IActionResult Success(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("id");
            if (id != UserId){
                return RedirectToAction("Index", "User");
            }
            User user = _context.Users.Include(u => u.Withdrawals).Single(n => n.Id == id);
            ViewBag.Info = user;
            return View();
        }

        [Route("withdraw")]
        [HttpPost]
        public IActionResult Withdraw(Withdrawal model)
        {
            Withdrawal NewWithdrawal = new Withdrawal();
            int userid = (int)HttpContext.Session.GetInt32("id");
            NewWithdrawal.UserId = userid;
            NewWithdrawal.Amount = model.Amount;
            NewWithdrawal.CreatedAt = DateTime.Now;
            NewWithdrawal.UpdatedAt = DateTime.Now;
            _context.Withdrawals.Add(NewWithdrawal);
            User user = _context.Users.Single(n => n.Id == userid);
            user.Balance += model.Amount;
            _context.SaveChanges();
            return RedirectToAction("Success", "Dash", new {id = userid});
        }
    }
}
