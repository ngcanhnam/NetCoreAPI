using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FirstWebMVC.Models;
using System.Security.Cryptography.X509Certificates;

namespace FirstWebMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(string fullname, string Address){
        string strOutput = "Xin chào" + fullname + "đến từ" + Address;
        ViewBag.Message = strOutput;
        return View();
        ;

    }
}
