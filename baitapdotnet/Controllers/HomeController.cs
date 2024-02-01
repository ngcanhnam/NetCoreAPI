using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using baitapdotnet.Models;

namespace baitapdotnet.Controllers;

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
   public IActionResult Index(string Fullname, string Address){
    string strOutput = "xin chào" +  Fullname +   "đến từ" +    Address;
    ViewBag.Message = strOutput;
    return View();
   }
}
