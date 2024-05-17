
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using MvcMovie.Data;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MvcMovie.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context){
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _context.Employee.ToListAsync();
            return View(model);
        }
        public IActionResult Create(){
            return View();
        }
        public async Task<IActionResult> Update(string id){
            if (id == null || _context.Employee == null)
            {
                return NotFound();
            }
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null){
            return NotFound();}
            return View(employee);
        }
        public async Task<IActionResult> Delete (string id){
            if (id == null  || _context.Employee == null)
            {
                return NotFound();
            } 
            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
                if (employee == null){
                    return NotFound();
                }
                return View(employee);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Employee == null)
        {
            return Problem("Enity set 'ApplicationDbContext.Employee' is null.");
        }            
            var employee = await _context.Employee.FindAsync(id);
            if (employee != null){
                _context.Employee.Remove(employee);
            }
            await _context.SaveChangesAsync(); 
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonId, FullName, Address, Age")] Employee employee){
            if (ModelState.IsValid){
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction (nameof(Index));
            }
            return View(employee);
        }
        private bool PersonExists(string id){
            return (_context.Employee?.Any(e => e.EmployeeId == id)).GetValueOrDefault();
        }


        [HttpPost]
        public IActionResult Index(Employee ps)
        {
            string strOutput = " Xin chào " +"-" + ps.FullName + "-" +  ps.Address + "-" + ps.EmployeeId + "-" + ps.Age;
            ViewBag.infoEmployee = strOutput;
            return View();
        }
        
        
    }
    

}