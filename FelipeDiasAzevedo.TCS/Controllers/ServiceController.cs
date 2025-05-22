using FelipeDiasAzevedo.TCS.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace FelipeDiasAzevedo.TCS.Controllers;

public class ServiceController(ISystemService systemService) : Controller
{
    public IActionResult Index()
    {
        return View(systemService.CheckGeneralStatus());
    }

    public IActionResult Start([FromQuery] string service)
    {
        var serviceStatus = systemService.CheckService(service);

        if (serviceStatus is null)
        {
            return RedirectToAction("Index");
        }

        return View(serviceStatus);
    }

    [HttpPost]
    public IActionResult StartService([FromQuery] string service)
    {
        systemService.StartService(service);

        return RedirectToAction("Index");
    }

    public IActionResult Stop([FromQuery] string service)
    {
        var serviceStatus = systemService.CheckService(service);

        if (serviceStatus is null)
        {
            return RedirectToAction("Index");
        }

        return View(serviceStatus);
    }

    [HttpPost]
    public IActionResult StopService([FromQuery] string service)
    {
        systemService.StopService(service);

        return RedirectToAction("Index");
    }
}
