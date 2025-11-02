using Microsoft.AspNetCore.Mvc;

namespace S12_DependencyInjection.Controllers;

public class HomeController : Controller
{

    [Route("/")]
    public IActionResult Index()
    {
        return View();
    }
}
