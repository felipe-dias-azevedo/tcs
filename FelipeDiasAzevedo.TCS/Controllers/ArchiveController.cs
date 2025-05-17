using FelipeDiasAzevedo.TCS.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace FelipeDiasAzevedo.TCS.Controllers;

public class ArchiveController(ISystemService systemService) : Controller
{
    public IActionResult Index()
    {
        return View(systemService.ListArchiveDirectories());
    }

    [HttpPost]
    public IActionResult Download()
    {
        throw new NotImplementedException();
    }
}
