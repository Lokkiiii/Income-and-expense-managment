using ExpenseManagement.DataAccess.Models;
using ExpenseManagement.DataAccess.Providers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace IncomManagement.Controllers
{
    public class IncomeController : Controller
    {
        public IActionResult Index()
        {
            int usr = HttpContext.Session.GetInt32("UserId").Value;
            IncomeProvider incomeProvider = new IncomeProvider();
            List<Income> incomes = incomeProvider.ListIncomes(usr);
            return View("Search",incomes);
            
        }
   
        
        [HttpGet]
       
        public IActionResult Search(string searching)
        {
            int usr = HttpContext.Session.GetInt32("UserId").Value;
            IncomeProvider incomeProvider = new IncomeProvider();
            List<Income> incomes = incomeProvider.ListIncomes(usr,searching);
            ViewData["Getincomedetails"] = searching;

            return View(incomes);

        }
        
    

        public IActionResult Insert(Income income)
        {
            income.UserId = HttpContext.Session.GetInt32("UserId").Value;
            IncomeProvider incomeProvider = new IncomeProvider();
            incomeProvider.InsertIncomes(income);
            return View();
        }
        public IActionResult List()
        {
            int usr = HttpContext.Session.GetInt32("UserId").Value;
            IncomeProvider incomeProvider = new IncomeProvider(); 
            List<Income> incomes = incomeProvider.ListIncomes(usr);
            return View(incomes);
        }

     
    }
}
