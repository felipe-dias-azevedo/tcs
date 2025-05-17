using FelipeDiasAzevedo.TCS.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace FelipeDiasAzevedo.TCS.Controllers;

public class StatusController(ISystemService systemService) : Controller
{
    public IActionResult Index()
    {
        return View(systemService.CheckGeneralStatus());
    }
}
