using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;
using System.Data;
using MvcMovie.Migrations;
using System.Security.Cryptography;

namespace MvcMovie.Controllers{
    public class HethongphanphoiController : Controller{
        private readonly ApplicationDbContext _context;
        public HethongphanphoiController(ApplicationDbContext context){
            _context = context;
        }
//GET Index
    public async Task<IActionResult> Index(){
        return _context.Hethongphanphoi != null ?
                View(await _context.Hethongphanphoi.ToListAsync()) :
                Problem("");

    }
//GET Create
    public IActionResult Create(){
        return View();
    }
//POST Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("HTPPId, HTPPName")] Hethongphanphoi hethongphanphoi){
      if(ModelState.IsValid){
        _context.Add(hethongphanphoi);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index)); 
      }
      return View();
    }
//GET Edit
    public async Task<IActionResult> Edit(string id){
        if(id == null || _context.Hethongphanphoi == null){
            return NotFound();
        }
        var hethongphanphoi = await _context.Hethongphanphoi.FindAsync(id);
        if(hethongphanphoi == null){
            return NotFound("");
        }
        return View();
    }

//POST Edit
        public async Task<IActionResult> Edit(string id, [Bind("HTPPId, HTPPName")]Hethongphanphoi hethongphanphoi){
            if ( id != hethongphanphoi.HTPPId){
                return NotFound();
            }
            if (ModelState.IsValid){
                try{
                    _context.Update(hethongphanphoi);
                    await _context.SaveChangesAsync();

                }
                catch(DbUpdateConcurrencyException){
                    if(HethongphanphoiExists(hethongphanphoi.HTPPId)){
                        return NotFound();
                    }
                    else{
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        private bool HethongphanphoiExists(string id)
        {
          return (_context.Hethongphanphoi?.Any(e => e.HTPPId == id)).GetValueOrDefault();
        }
    }
}