using Microsoft.AspNetCore.Mvc;
using MVCMovie.Models;

namespace MVCMovie.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index(){
            return View();
        }
        [HttpPost]
        public IActionResult Index(Person ps)
        {
            string strOutput = "Xin chào " + ps.PersonID + "-" + ps.fullname + "-" + ps.Address;
            ViewBag.infoPerson = strOutput;
            return View();
        }
    
    }

}