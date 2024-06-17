using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CanhNamtest;
using CanhNamtest.Models.ViewModels;
using OfficeOpenXml;
using X.PagedList;
using X.PagedList.Mvc.Core;
using CanhNamtest.Models.Process;

namespace CanhNamtest.Controllers
{
    public class SinhvienController : Controller
    {
        private readonly LTQLDb _context;
        private ExcelProcess _excelProcess = new ExcelProcess();

        public SinhvienController(LTQLDb context)
        {
            _context = context;
        }

        // GET: Sinhvien
              public async Task<IActionResult> Index(int? page, int? PageSize){
            ViewBag.PageSize = new List<SelectListItem>(){
                new SelectListItem() {Value = "3", Text = "3"},
                new SelectListItem() {Value = "5", Text = "5"},
                new SelectListItem() {Value = "10", Text = "10"},
                new SelectListItem() {Value = "15", Text = "15"},   
                new SelectListItem() {Value = "25", Text = "25"},   
                new SelectListItem() {Value = "50", Text = "50"},   
            };
            int pagesize = (PageSize ?? 3);
            ViewBag.psize = pagesize;
            var model = _context.Sinhvien.ToList().ToPagedList(page ?? 1, pagesize);
            // var model = _context.Persons.ToList().ToPagedList(page ?? 1, 5);
            return View(model);
        }


        // GET: Sinhvien/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhvien = await _context.Sinhvien
                .FirstOrDefaultAsync(m => m.Masinhvien == id);
            if (sinhvien == null)
            {
                return NotFound();
            }

            return View(sinhvien);
        }

        // GET: Sinhvien/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sinhvien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Masinhvien,Hoten,Malop")] Sinhvien sinhvien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sinhvien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sinhvien);
        }

        // GET: Sinhvien/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhvien = await _context.Sinhvien.FindAsync(id);
            if (sinhvien == null)
            {
                return NotFound();
            }
            return View(sinhvien);
        }

        // POST: Sinhvien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Masinhvien,Hoten,Malop")] Sinhvien sinhvien)
        {
            if (id != sinhvien.Masinhvien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sinhvien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SinhvienExists(sinhvien.Masinhvien))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sinhvien);
        }

        // GET: Sinhvien/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhvien = await _context.Sinhvien
                .FirstOrDefaultAsync(m => m.Masinhvien == id);
            if (sinhvien == null)
            {
                return NotFound();
            }

            return View(sinhvien);
        }

        // POST: Sinhvien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sinhvien = await _context.Sinhvien.FindAsync(id);
            if (sinhvien != null)
            {
                _context.Sinhvien.Remove(sinhvien);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SinhvienExists(string id)
        {
            return _context.Sinhvien.Any(e => e.Masinhvien == id);
        }

//GET Index2 
       public async Task<IActionResult> Index2(int malop){
        malop =1;
        var querry =(from std in _context.Sinhvien 
                        join Lophoc in _context.Lophoc
                        on std.Malop equals Lophoc.Malop
                        where Lophoc.Malop == malop
                        select new SinhvienVm{

                            Masinhvien = std.Masinhvien,
                            Hovaten = std.Hoten,
                            Malop = Lophoc.Malop,
                            Tenlop = Lophoc.Tenlop,
                        }).ToList().Take(2);
                return View(querry);
       }

         public IActionResult Download(){
            //Name the file when downloading
            var fileName = "NguyenCanhNam27/01" + ".xlsx";
            using(ExcelPackage excelPackage = new ExcelPackage()){
                //Create the WorkSheet
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet 1");
                //Add some text to cell A1
                worksheet.Cells["A1"].Value = "PersonID";
                worksheet.Cells["B1"].Value = "FullName";
                worksheet.Cells["C1"].Value = "Address";
                //get all Person
                var personsList = _context.Sinhvien.ToList();
                //fill data to worksheet
                worksheet.Cells["A2"].LoadFromCollection(personsList);
                var stream = new MemoryStream(excelPackage.GetAsByteArray());
                //download file
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
        }



        }
   


}


