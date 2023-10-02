using Microsoft.AspNetCore.Mvc;

namespace TP09-Login MVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
