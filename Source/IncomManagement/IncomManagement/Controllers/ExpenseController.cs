using ExpenseManagement.DataAccess.Models;
using ExpenseManagement.DataAccess.Providers;
using Microsoft.AspNetCore.Mvc;

namespace IncomManagement.Controllers
{
    public class ExpenseController : Controller
    {
        public IActionResult List2()
        {
            int usr = HttpContext.Session.GetInt32("UserId").Value;
            ExpenseProvider expenseProvider = new ExpenseProvider();
            List<Expense> expenses = expenseProvider.ListExpenses(usr);
            return View("Search",expenses);
            
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Search(string searching)
        {
            int usr = HttpContext.Session.GetInt32("UserId").Value;
            ExpenseProvider expenseProvider = new ExpenseProvider();
            List<Expense> expenses = expenseProvider.ListExpenses(usr,searching);
            ViewData["Getexpensedetails"] = searching;

            return View(expenses);

        }
        [HttpPost]
        public IActionResult Insert(Expense expense)
        {
            expense.UserId = HttpContext.Session.GetInt32("UserId").Value;
            ExpenseProvider expenseProvider = new ExpenseProvider();
            expenseProvider.InsertExpenses(expense);
            return View();
        }
        public IActionResult List()
        {
            int usr = HttpContext.Session.GetInt32("UserId").Value;
            ExpenseProvider expenseProvider = new ExpenseProvider();
            List<Expense> expenses = expenseProvider.ListExpenses(usr);
            return View("Search", expenses); 
        }
    }
}
