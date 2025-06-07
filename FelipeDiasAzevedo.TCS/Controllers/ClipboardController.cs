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
    public async Task<IActionResult> Create(UpsertClipboardViewModel viewModel)
    {
        if (!ModelState.IsValid) return View(viewModel);

        await clipboardService.Save(viewModel);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(string id)
    {
        return View(await clipboardService.GetById(id));
    }

    [HttpPost]
    public async Task<IActionResult> Edit(UpsertClipboardViewModel viewModel)
    {
        if (!ModelState.IsValid) return View(viewModel);

        await clipboardService.Update(viewModel);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(string id)
    {
        return View(await clipboardService.GetById(id));
    }

    [ActionName("Delete")]
    [HttpPost]
    public async Task<IActionResult> DeleteClipboard(string id)
    {
        await clipboardService.Delete(id);

        return RedirectToAction("Index");
    }
}
