using System.Diagnostics;
using FelipeDiasAzevedo.TCS.Business.Services;
using FelipeDiasAzevedo.TCS.Business.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FelipeDiasAzevedo.TCS.Controllers;

public class HomeController(ISystemService systemService) : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Shutdown()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ShutdownSystem()
    {
        systemService.Shutdown();

        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
