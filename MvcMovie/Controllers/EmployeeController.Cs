using MVCMovie.Models;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Employee ps)
        {
            string strOutput = " Xin chào " + ps.PersonId + "-" + ps.FullName + "-" +  ps.Address + "-" + ps.EmployeeId + "-" + ps.Age;
            ViewBag.infoEmployee = strOutput;
            return View();
        }
    }
}