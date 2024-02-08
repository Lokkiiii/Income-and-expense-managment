using ExpenseManagement.DataAccess.Models;
using ExpenseManagement.DataAccess.Providers;
using Microsoft.AspNetCore.Mvc;

namespace IncomManagement.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            string userId = HttpContext.Session.GetString("UserId");
            return View("Index",(object)"User Id in session-"+userId);
        }
        [HttpPost]
        public IActionResult Insert(Client client )
        {
            ClientProvider clientProvider = new ClientProvider();
            clientProvider.InsertUser( client );
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            Client model = new Client();

            return View(model);

        }
        [HttpPost]
        public IActionResult Home(Client model)
        {
            

            ClientProvider userProvider = new ClientProvider();
            int rst = userProvider.LoginUser(model.UserEmail, model.UserPassword);
            if (rst!=0)
            {
                HttpContext.Session.SetInt32("UserId", rst);
               
                return View("Income");
            }
            else
            {
                return View("Invalid");
            }
        }
        public IActionResult Income()
        {
            return View();
        }
     





    }
}
