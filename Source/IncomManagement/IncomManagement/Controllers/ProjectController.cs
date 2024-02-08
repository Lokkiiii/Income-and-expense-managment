using ExpenseManagement.DataAccess.Models;
using ExpenseManagement.DataAccess.Providers;
using Microsoft.AspNetCore.Mvc;

namespace IncomManagement.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Income()
        {
            return View();
        }
        public IActionResult Expense()
        {
            return View();
        }
      
    }
}
