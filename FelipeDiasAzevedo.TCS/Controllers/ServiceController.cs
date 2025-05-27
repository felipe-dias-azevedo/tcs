using FelipeDiasAzevedo.TCS.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace FelipeDiasAzevedo.TCS.Controllers;

public class ServiceController(ISystemService systemService) : Controller
{
    public IActionResult Index()
    {
        return View(systemService.CheckGeneralStatus());
    }

    public IActionResult Start([FromQuery] string name)
    {
        var serviceStatus = systemService.CheckService(name);

        if (serviceStatus is null)
        {
            return RedirectToAction("Index");
        }

        return View(serviceStatus);
    }

    [HttpPost]
    public IActionResult StartService([FromQuery] string name)
    {
        systemService.StartService(name);

        return RedirectToAction("Index");
    }

    public IActionResult Stop([FromQuery] string name)
    {
        var serviceStatus = systemService.CheckService(name);

        if (serviceStatus is null)
        {
            return RedirectToAction("Index");
        }

        return View(serviceStatus);
    }

    [HttpPost]
    public IActionResult StopService([FromQuery] string name)
    {
        systemService.StopService(name);

        return RedirectToAction("Index");
    }
}
