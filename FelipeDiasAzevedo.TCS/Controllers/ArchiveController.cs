using FelipeDiasAzevedo.TCS.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace FelipeDiasAzevedo.TCS.Controllers;

public class ArchiveController(IFileService fileService) : Controller
{
    public IActionResult Index()
    {
        return View(fileService.ListArchiveDirectories());
    }

    public IActionResult Download([FromQuery] string path)
    {
        var file = fileService.Archive(path);

        return File(file.Stream, file.ContentType, file.FileName);
    }
}
