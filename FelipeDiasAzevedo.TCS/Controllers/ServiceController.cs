using FelipeDiasAzevedo.TCS.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace FelipeDiasAzevedo.TCS.Controllers;

public class ServiceController(ISystemService systemService) : Controller
{
    public IActionResult Index()
    {
        return View(systemService.GetServices());
    }

    public IActionResult Details([FromQuery] string name)
    {
        var serviceStatus = systemService.GetService(name, includeLogs: true);

        if (serviceStatus is null)
        {
            return RedirectToAction("Index");
        }

        return View(serviceStatus);
    }

    public IActionResult Start([FromQuery] string name)
    {
        var serviceStatus = systemService.GetService(name);

        if (serviceStatus is null || !serviceStatus.CanStart)
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
        var serviceStatus = systemService.GetService(name);

        if (serviceStatus is null || !serviceStatus.CanStop)
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
