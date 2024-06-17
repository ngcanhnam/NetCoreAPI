using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Testlacuoi.Models;
using Testlacuoi.Models.Process;
using Testlacuoi.Models.ViewModels;
using X.PagedList;

namespace Testlacuoi.Controllers
{
    public class SinhVienController : Controller
    {
        private readonly LTQLDb _context;

        public SinhVienController(LTQLDb context)
        {
            _context = context;
        }
        private ExcelProcess _excelProcess = new ExcelProcess();

        // GET: SinhVien
      public async Task<IActionResult> Index(int? page, int? PageSize){
        ViewBag.PageSize = new List<SelectListItem>(){
            new SelectListItem(){Value = "3", Text = "3"},
            new SelectListItem(){Value = "5", Text ="5"}
        };
        int pagesize = (PageSize ?? 3);
        ViewBag.psize = pagesize;
        var model = _context.SinhVien.ToList().ToPagedList(page ??1, pagesize);
        return View(model);
      }

        // GET: SinhVien/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhVien
                .FirstOrDefaultAsync(m => m.MaSinhVien == id);
            if (sinhVien == null)
            {
                return NotFound();
            }

            return View(sinhVien);
        }

        // GET: SinhVien/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SinhVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSinhVien,Hovaten,MaLop")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sinhVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sinhVien);
        }

        // GET: SinhVien/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhVien.FindAsync(id);
            if (sinhVien == null)
            {
                return NotFound();
            }
            return View(sinhVien);
        }

        // POST: SinhVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaSinhVien,Hovaten,MaLop")] SinhVien sinhVien)
        {
            if (id != sinhVien.MaSinhVien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sinhVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SinhVienExists(sinhVien.MaSinhVien))
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
            return View(sinhVien);
        }

        // GET: SinhVien/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sinhVien = await _context.SinhVien
                .FirstOrDefaultAsync(m => m.MaSinhVien == id);
            if (sinhVien == null)
            {
                return NotFound();
            }

            return View(sinhVien);
        }

        // POST: SinhVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sinhVien = await _context.SinhVien.FindAsync(id);
            if (sinhVien != null)
            {
                _context.SinhVien.Remove(sinhVien);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SinhVienExists(string id)
        {
            return _context.SinhVien.Any(e => e.MaSinhVien == id);
        }

        public async Task<IActionResult> index2 (int malop){
            malop = 1;
            var querry =(from std in _context.SinhVien 
                            join LopHoc in _context.LopHoc
                            on std.MaLop equals LopHoc.MaLop
                            where LopHoc.MaLop == malop
                            select new SinhVienVL{
                                MaSinhVien = std.MaSinhVien,
                                Hoten = std.Hovaten,
                                MaLop = LopHoc.MaLop,
                                TenLop = LopHoc.TenLop
                            }).ToList().Take(2);

                    return View(querry);
        }

        public async Task<IActionResult> Upload (IFormFile file){
            if (file == null){
                return BadRequest("file is required");
            }
            var FileExtention = Path.GetExtension(file.FileName);
            if(FileExtention.ToLower() != ".xlxs"){
                return  BadRequest("file ko dung dang");
            }
            var FileName = file.FileName;
            var FilePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", FileName);
            var FileLocation = new FileInfo(FilePath).ToString();
            var ExitstingStudent = _context.SinhVien.Select(e => e.MaSinhVien).ToList();

            using(var stream = new FileStream(FilePath, FileMode.Create)){
                await file.CopyToAsync(stream);
                var dt = _excelProcess.ExcelToDataTable(FileLocation);
                for (var i =0;  i<dt.Rows.Count; i ++){
                    if (!ExitstingStudent.Contains(dt.Rows[i]["0"])){
                        var sv = new SinhVien();
                        sv.MaSinhVien = dt.Rows[i]["0"].ToString();
                        sv.Hovaten = dt.Rows[i]["1"].ToString();
                        sv.MaLop = Convert.ToInt32(dt.Rows[i][3]);
                        _context.Add(sv);
                    }
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();

            }
          public async Task<IActionResult> Uploads(IFormFile file){
            if (file == null){
                return BadRequest("File is required");
            }
            var FileExtention = Path.GetExtension(file.FileName);
            if(FileExtention.ToLower() != ".xlxs" & FileExtention.ToLower() != ".xls"){
                return BadRequest("Ko dung dang file");

            }
            var FileName = file.FileName;
            var FilePhat = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", FileName); //duong dan file 
            var FileLocation = new FileInfo(FilePhat).ToString(); // đường dẫn file dưới dạng chuỗi 
            var ExStudent = _context.SinhVien.Select(e => e.MaSinhVien).ToList();//danh sách sinh viên đã tồn tại


            using (var stream = new FileStream(FilePhat, FileMode.Create)){
                await file.CopyToAsync(stream);

                var dt = _excelProcess.ExcelToDataTable(FileLocation);
                for (var i = 0; i< dt.Rows.Count; i++){
                    if(!ExStudent.Contains(dt.Rows[i]["0"])){

                        var sv = new SinhVien();
                        sv.MaSinhVien = dt.Rows[i]["0"].ToString();
                        sv.Hovaten = dt.Rows[i]["1"].ToString();
                        sv.MaLop =  Convert.ToInt32(dt.Rows[i]["2"]);
                        _context.Add(sv);
                    }
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();

          }

        }
    }

