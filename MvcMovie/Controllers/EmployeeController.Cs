
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;
using MvcMovie.Models.Process;
using OfficeOpenXml;
using System.Data;
using X.PagedList;

namespace MvcMovie.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        private ExcelProcess _excelProcess = new ExcelProcess();
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
        public async Task<IActionResult> Upload(){
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null)
            {
                try
                {
                    string fileExtension = Path.GetExtension(file.FileName);
                    if (fileExtension != ".xls" && fileExtension != ".xlsx")
                    {
                        ModelState.AddModelError(string.Empty, "File must be .xls or .xlsx");
                    }
                    else
                    {
                        var fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + fileExtension;
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", "Excels", fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);

                            var dt = _excelProcess.ReadExcelToDataTable(filePath);

                            foreach (DataRow row in dt.Rows)
                            {
                                var Employee = new Employee
                                {
                                    FullName = row[0].ToString(),
                                    Address = row[1].ToString(),
                                    EmployeeId = row[2].ToString()
                                };
                                _context.Add(Employee);
                            }

                            await _context.SaveChangesAsync();
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions (e.g., log the error, display a user-friendly message)
                    ModelState.AddModelError(string.Empty, $"Error processing Excel file: {ex.Message}");
                }
            }

            return View();
        }
         public IActionResult Download(){
            //Name the file when downloading
            var fileName = "Nguyễn Cảnh Nam-2121050710" + ".xlsx";
            using(ExcelPackage excelPackage = new ExcelPackage()){
                //Create the WorkSheet
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet 1");
                //Add some text to cell A1
                worksheet.Cells["A1"].Value = "FullName";
                worksheet.Cells["B1"].Value = "Address";
                worksheet.Cells["C1"].Value = "EmployeeId";
                //get all Person
                var personsList = _context.Persons.ToList();
                //fill data to worksheet
                worksheet.Cells["A2"].LoadFromCollection(personsList);
                var stream = new MemoryStream(excelPackage.GetAsByteArray());
                //download file
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
        }

        
        
    }
    

}