using FelipeDiasAzevedo.TCS.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace FelipeDiasAzevedo.TCS.Controllers;

public class ServiceController(ISystemService systemService) : Controller
{
    public IActionResult Index()
    {
        return View(systemService.CheckGeneralStatus());
    }

    [HttpPost]
    public IActionResult Start() // TODO: add query param for service name
    {
        systemService.StartService();

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Stop() // TODO: add query param for service name
    {
        systemService.StopService();

        return RedirectToAction("Index");
    }
}
