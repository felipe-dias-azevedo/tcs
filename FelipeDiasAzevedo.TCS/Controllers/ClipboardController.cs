using System.Threading.Tasks;
using FelipeDiasAzevedo.TCS.Business.Services;
using FelipeDiasAzevedo.TCS.Business.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FelipeDiasAzevedo.TCS.Controllers;

public class ClipboardController(IClipboardService clipboardService) : Controller
{
    public async Task<IActionResult> Index()
    {
        return View(await clipboardService.Get());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateClipboardViewModel createClipboard)
    {
        if (!ModelState.IsValid) return View(createClipboard);

        // await clipboardService.Save(createClipboard);

        return RedirectToAction("Index");
    }
}
