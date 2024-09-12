using Microsoft.AspNetCore.Mvc;
using Task2MVC.Data;
using Task2MVC.Models;

namespace Task2MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext context;

        public UsersController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var users = context.Users.Where(user => user.IsActive == false);
            return View(users);
        }
        public IActionResult Delete(Guid id)
        {
            var user = context.Users.Find(id);
            context.Users.Remove(user);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(Guid id)
        {
            var user = context.Users.Find(id);
            return View(user);
        }
        [HttpPost]
        public IActionResult Update(User user)
        {
            var userDb = context.Users.Find(user.UserId);
            userDb.UserName = user.UserName;
            userDb.Password = user.Password;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            var checkUser = context.Users.Where(x => x.UserName == user.UserName && x.Password == user.Password);
            if (checkUser.Any())
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Error = "Invalid User Name Or Password";
            return View(user);
        }

        public IActionResult Change(Guid id)
        {
            var user = context.Users.Find(id);
            user.IsActive = true;
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
